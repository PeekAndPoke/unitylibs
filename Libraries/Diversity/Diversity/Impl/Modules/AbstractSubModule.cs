using De.Kjg.Diversity.Interfaces.DI;
using De.Kjg.Diversity.Interfaces.Modules;

namespace De.Kjg.Diversity.Impl.Modules
{
    public abstract class AbstractSubModule : AbstractMainModule, ISubModule
    {
        protected IMainModule ParentModule;

        public abstract void Initialize();

        public override IDependencyInjectionContainer GetDependencyInjectionContainer()
        {
            return GetParentModule().GetDependencyInjectionContainer();
        }

        public IMainModule GetParentModule()
        {
            return ParentModule;
        } 

        public void SetParentModule(IMainModule parent)
        {
            ParentModule = parent;
        }
    }
}
