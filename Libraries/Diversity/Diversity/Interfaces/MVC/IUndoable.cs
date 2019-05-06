namespace De.Kjg.Diversity.Interfaces.MVC
{
    public interface IUndoable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns true if the undo was completed successfully</returns>
        bool Undo();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns true if the redo was completed successfully</returns>
        bool Redo();
    }
}
