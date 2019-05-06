using De.Kjg.Diversity.Interfaces.MVC.Mediators;

namespace De.Kjg.Diversity.Impl.MVC.Mediators
{
    abstract public class GameObjectMediator : AbstractBaseMediator, IGameObjectMediator
    {
        abstract public void Initialize();
    }
}
