namespace De.Kjg.Diversity.Unity.Debug.Remote
{
    public class RemoteRenderCommand
    {
        public string MethodName;
        public object[] Parameters;

        public RemoteRenderCommand()
        {
        }

        public RemoteRenderCommand(string methodName, object[] parameters)
        {
            MethodName = methodName;
            Parameters = parameters;
        }
    }
}
