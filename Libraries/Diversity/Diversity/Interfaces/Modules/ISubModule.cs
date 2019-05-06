namespace De.Kjg.Diversity.Interfaces.Modules
{
    public interface ISubModule
    {
        void Initialize();

        IMainModule GetParentModule();

        void SetParentModule(IMainModule parent);

        void Update();

        void UpdateGui();
    }
}
