namespace De.Kjg.Diversity.Interfaces.Signals
{
    public delegate void Slot(params object[] parameters);

    public interface ISignal
    {
        void Add(Slot slot, int priority = 0);
        void AddOnce(Slot slot, int priority = 0);
        bool Has(Slot slot);
        void Remove(Slot slot);
        void RemoveAll();
        void Dispatch(params object[] parameters);
        void DispatchArgs(object[] parameters);
    }
}