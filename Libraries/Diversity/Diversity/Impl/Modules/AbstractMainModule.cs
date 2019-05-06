using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.DI;
using De.Kjg.Diversity.Interfaces.Modules;

namespace De.Kjg.Diversity.Impl.Modules
{
    public abstract class AbstractMainModule : IMainModule
    {
        protected List<ISubModule> SubModules = new List<ISubModule>(); 

        public abstract IDependencyInjectionContainer GetDependencyInjectionContainer();

        public void AddSubModule(ISubModule subModule)
        {
            SubModules.Add(subModule);
            subModule.SetParentModule(this);
            GetDependencyInjectionContainer().Inject(subModule);
            subModule.Initialize();
        }

        public virtual void Update()
        {
            foreach (var sub in SubModules)
            {
                sub.Update();
            }
        }

        public virtual void UpdateGui()
        {
            foreach (var sub in SubModules)
            {
                sub.UpdateGui();
            }
        }
    }
}
