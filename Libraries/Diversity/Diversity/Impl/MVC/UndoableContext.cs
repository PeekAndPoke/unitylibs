using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.DI;
using De.Kjg.Diversity.Interfaces.MVC;
using De.Kjg.Diversity.Interfaces.MVC.Commands;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Interfaces.UXs.Scenes;

namespace De.Kjg.Diversity.Impl.MVC
{
    /// <summary>
    /// Context that handles undo and redo of commands the implement the IUndoable interface.
    /// </summary>
    public class UndoableContext : DefaultContext
    {
        /// <summary>
        /// undo-able command history
        /// </summary>
        protected List<IUndoable> UndoableCommandHistory = new List<IUndoable>();
        /// <summary>
        /// Pointer to the current command in the undo-able history
        /// </summary>
        protected int UndoableCommandsPointer = -1;

        /// <summary>
        /// C'tor
        /// </summary>
        /// <see cref="DefaultContext"/>
        public UndoableContext(IGuiElement guiElement, IScene scene, IDependencyInjectionKernel dependencyInjectionKernel) : 
            base(guiElement, scene, dependencyInjectionKernel)
        {
            ClearUndoHistory();
        }

        /// <summary>
        /// Undos a command and decreases the pointer inside of the history
        /// </summary>
        public void Undo()
        {
//            UnityEngine.Debug.Log("Undo length " + UndoableCommandHistory.Count);
//            UnityEngine.Debug.Log("Undo pointer " + UndoableCommandsPointer);
            
            if (UndoableCommandsPointer >= 0)
            {
                // undo the command
                UndoableCommandHistory[UndoableCommandsPointer].Undo();
                // reduce the point by one
                UndoableCommandsPointer--;
            }
        }

        /// <summary>
        /// Redos a command and increases the pointer inside of the history
        /// </summary>
        public void Redo()             
        {
//            UnityEngine.Debug.Log("Redo length " + ((UndoableCommandHistory.Count - UndoableCommandsPointer) - 1));
//            UnityEngine.Debug.Log("Undo pointer " + UndoableCommandsPointer);

            if (UndoableCommandsPointer < UndoableCommandHistory.Count - 1)
            {
                UndoableCommandsPointer++;
                UndoableCommandHistory[UndoableCommandsPointer].Redo();
            }
        }

        /// <summary>
        /// Deletes the complete undo history
        /// </summary>
        public void ClearUndoHistory()
        {
            UndoableCommandHistory.Clear();
            UndoableCommandsPointer = -1;
        }

        /// <summary>
        /// Executes a command and adds it to the history if it implements IUndoable
        /// </summary>
        /// <param name="commandClass">command class type</param>
        /// <param name="args">parameters for executing commands Execute() method</param>
        protected override void ExecuteCommand(Type commandClass, object[] args)
        {
            var command = (ICommand)DependencyInjectionKernel.Get(commandClass);
            var success = command.Execute(args);

            // when the command was executed successfully and it is undobale we need to remember it
            if (success && command is IUndoable)
            {
                // increase the pointer by one
                UndoableCommandsPointer++;

                // remove items from the history the are after the pointer
                UndoableCommandHistory.RemoveRange(UndoableCommandsPointer, UndoableCommandHistory.Count - UndoableCommandsPointer);

                UndoableCommandHistory.Add((IUndoable)command);
                // set the pointer to the last element
                UndoableCommandsPointer = UndoableCommandHistory.Count - 1;

//                UnityEngine.Debug.Log("UndoableCommandsPointer: " + UndoableCommandsPointer);
            }
        }

    }
}
