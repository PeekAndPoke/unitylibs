namespace De.Kjg.Diversity.Interfaces.MVC.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>True if the command was successfully executed</returns>
        bool Execute(params object[] parameters);
    }
}