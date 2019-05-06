using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.DI;
using De.Kjg.Diversity.Interfaces.MVC.Commands;
using De.Kjg.Diversity.Interfaces.MVC.Mediators;
using De.Kjg.Diversity.Interfaces.Signals;
using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Interfaces.UXs.Scenes;

namespace De.Kjg.Diversity.Impl.MVC
{
    /// <summary>
    /// The default mvc context.
    /// 
    /// The context automatically creates and destroyes Mediators for Gui Elements Type.
    /// When a Mediator is registered for a gui elements, then the mediator is create when the element
    /// is added to the stage (OnAddedToStage event is observed) and the mediator is drestoryed when
    /// the gui element is removed from the stage (OnRemovedFromStage is observed).
    /// 
    /// The context also routes signals to commands.
    /// When a signal is registered the according command is intantiated and executed.
    /// 
    /// There is also a context implementation that handles undo-able commands. 
    /// <see cref="UndoableContext"/>
    /// 
    /// </summary>
    public class DefaultContext
    {
        /// <summary>
        /// gui element instance of this context (needed to listen to OnAddedToStage and OnRemovedFromStage)
        /// </summary>
        protected readonly IGuiElement GuiElement;
        /// <summary>
        /// The 3D-Scene
        /// </summary>
        protected readonly IScene Scene;
        /// <summary>
        /// the di dependencyInjectionKernel
        /// </summary>
        protected readonly IDependencyInjectionKernel DependencyInjectionKernel;

        /// <summary>
        /// Maps IGuiElements to IMediators
        /// </summary>
        protected Dictionary<Type, Type> ViewMap = new Dictionary<Type, Type>();
        /// <summary>
        /// Stores all mediators attached to one IGuiElement. We need this information to be able to destroy the mediators when
        /// the gui element is removed from the stage.
        /// </summary>
        protected Dictionary<IGuiElement, List<IMediator>> ActiveMediators = new Dictionary<IGuiElement, List<IMediator>>();
        /// <summary>
        /// Maps signals to command. This is used to execute command by triggering a signal.
        /// </summary>
        protected Dictionary<Delegate, ICommand> SignalCommandMap = new Dictionary<Delegate, ICommand>();

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="guiElement">Main gui element of the context</param>
        /// <param name="scene">The 3D-Scene</param>
        /// <param name="dependencyInjectionKernel">The DI dependencyInjectionKernel to be used</param>
        public DefaultContext(IGuiElement guiElement, IScene scene, IDependencyInjectionKernel dependencyInjectionKernel)
        {
            GuiElement = guiElement;
            Scene = scene;
            DependencyInjectionKernel = dependencyInjectionKernel;

            // use low priority to ensure we get the event as the last
            guiElement.OnAddedToStage(HandleAddedToStage, false, -100000);
            guiElement.OnRemovedFromStage(HandleRemovedFromStage);
        }

        /// <summary>
        /// Check if we need to create a mediator for an added gui element.
        /// 
        /// If the type of the added gui element is registered with a mediator, the mediator is created.
        /// </summary>
        /// <param name="e">The event</param>
        protected void HandleAddedToStage(IEvent e)
        {
            var guiElement = e.Target;
            Type mediatorType;
            if (ViewMap.TryGetValue(guiElement.GetType(), out mediatorType))
            {
                var newMediator = (IMediator) DependencyInjectionKernel.Get(mediatorType);

//                UnityEngine.Debug.Log("found mediator for " + guiElement.GetType().FullName + " => " + newMediator.GetType().FullName);
                newMediator.SetGuiElement(guiElement);
                newMediator.Initialize();
                // check if there is already a list of mediators for this gui element
                if (!ActiveMediators.ContainsKey(guiElement))
                {
                    ActiveMediators[guiElement] = new List<IMediator>();
                }
                // get the mediator list for the gui element
                List<IMediator> mediators;
                ActiveMediators.TryGetValue(guiElement, out mediators);
                mediators.Add(newMediator);
            }
        }

        /// <summary>
        /// Check if we need to destroy a mediator for an added gui element.
        /// 
        /// If the gui elements is associated with mediators we destroy them. 
        /// </summary>
        /// <param name="e"></param>
        protected void HandleRemovedFromStage(IEvent e)
        {
            var guiElement = e.Target;
            // are we managing the element?
            if (ActiveMediators.ContainsKey(guiElement))
            {
                // get the mediator list
                List<IMediator> mediators;
                ActiveMediators.TryGetValue(guiElement, out mediators);
                // destroy all mediators
                foreach (var mediator in mediators)
                {
                    mediator.Destroy();
                }
                // remove the entry from the active mediators dictionary
                ActiveMediators.Remove(guiElement);
            }
        }

        /// <summary>
        /// Map a gui element type to a mediator type.
        /// </summary>
        /// <typeparam name="TViewType">Gui element type</typeparam>
        /// <typeparam name="TMediatorType">Mediator type</typeparam>
        protected void MapView<TViewType, TMediatorType>() 
            where TViewType : IGuiElement
            where TMediatorType : IMediator
        {
            ViewMap.Add(typeof(TViewType), typeof(TMediatorType));
        }

        /// <summary>
        /// Maps a signal to a command. When the signal is deispatcher the command is created and executed.
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="commandClass"></param>
        protected void MapSignal(ISignal signal, Type commandClass)
        {
            signal.Add(args => ExecuteCommand(commandClass, args));
        }

        /// <summary>
        /// Maps a signal to a method. When the signal is dispatcher the method is called.
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="slot"></param>
        protected void MapSignal(ISignal signal, Slot slot)
        {
            signal.Add(slot);
        }

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="commandClass"></param>
        /// <param name="args"></param>
        protected virtual void ExecuteCommand(Type commandClass, object[] args)
        {
            var command = (ICommand)DependencyInjectionKernel.Get(commandClass);
            command.Execute(args);
        }
    }
}
