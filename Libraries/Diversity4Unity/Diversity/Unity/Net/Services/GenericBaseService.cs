namespace De.Kjg.Diversity.Unity.Net.Services
{
    abstract public class GenericBaseService<TServiceType> : BaseService
    {
        private TServiceType AsServiceType()
        {
            return (TServiceType) (object) this;
        }
    }

}
