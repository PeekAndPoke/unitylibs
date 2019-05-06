using System;
using System.Linq;
using De.Kjg.Diversity.Interfaces.MVC.Commands;

namespace De.Kjg.Diversity.Impl.MVC.Commands
{
    /// <summary>
    /// Type safe command implementation.
    /// 
    /// Type safe means, that you dont implement the Execute method with an array of parameters of unknown type.
    /// Instead you implement DoExecute(...) with exactly the parameters you expect.
    /// 
    /// This is achieved the reflection that is done in Execute(). We look for a DoExecute()-Method with the correct
    /// number of parameters. If we find such a method then this DoExecute()-method is called.
    /// 
    /// If you use the type safe command and get an Exception somewhere from inside TypeSafeCommand::Execute() then 
    /// you probably have something wrong with the number or parameters or their types in your DoExecute() impl.
    /// </summary>
    public class TypeSafeCommand : ICommand
    {
        public bool Execute(params object[] args)
        {
            // try to find an execute method with the correct signature
            var type = GetType();
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                if (method.Name == "DoExecute")
                {
                    var parameters = method.GetParameters();
                    var parameterCount = parameters.Count();
                    // do they have the same parameter count?
                    if (parameterCount == args.Count())
                    {
                        var castedArgs = new object[parameterCount];
                        // cast all args
                        for (var i = 0; i < parameterCount; ++i)
                        {
                            var parameterType = parameters[i].ParameterType;
                            castedArgs[i] = Convert.ChangeType(args[i], parameterType);
                        }

                        var ret = (bool) method.Invoke(this, castedArgs);
                        return ret;
                    }
                }
                return false;
            }

            var typesString = "";
            for (var i = 0; i < args.Count(); ++i)
            {
                if (i > 0)
                {
                    typesString += ", ";
                }

                typesString += args[i].GetType().FullName;
            }

            throw new Exception("No mathing method " + type.FullName + "::DoExecute(" + typesString + ") found. Cannot execute TypeSafeCommand.");
        }
    }
}
