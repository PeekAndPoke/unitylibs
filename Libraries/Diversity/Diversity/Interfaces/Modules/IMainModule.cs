using De.Kjg.Diversity.Interfaces.DI;

namespace De.Kjg.Diversity.Interfaces.Modules
{
    public interface IMainModule
    {
        IDependencyInjectionContainer GetDependencyInjectionContainer();

        void AddSubModule(ISubModule subModule);

        void Update();

        void UpdateGui();
    }
}
