using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Unity.Abstraction;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Server
{
    public class DebugServerRenderer : UnityGuiRenderer
    {
        public DebugServerRenderer(ISkin skin)
            : base(skin)
        {
        }

        public void RenderCommands(List<RemoteRenderCommand> commands)
        {
            var thisType = GetType();

            foreach (var command in commands)
            {
                var method = thisType.GetMethod(command.MethodName);

//                UnityEngine.Debug.Log("Trying to call " + command.MethodName + " with " + command.Parameters.Length + " parameters");
                try
                {
                    method.Invoke(this, command.Parameters);
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.Log("Trying to call " + command.MethodName + " with " + command.Parameters.Length + " parameters");
                    foreach (var p in command.Parameters)
                    {
                        UnityEngine.Debug.Log("param: " + p + " " + p.GetType().Name);
                    }
                    throw e;
                }
            }
        }
    }
}
