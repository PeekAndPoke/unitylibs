namespace De.Kjg.Diversity.Unity.Net.Loader
{
    abstract public class GenericBaseLoader<TLoaderType, TDoneHandler> : BaseLoader
    {
        protected GenericBaseLoader(UrlRequest request) : base(request)
        {
        }

        public TLoaderType Start()
        {
            LoadData();
            return AsLoaderType();
        }

        public TLoaderType AddDoneHandler(TDoneHandler doneHandler)
        {
            AddDoneHanlderInternal(doneHandler);
            return AsLoaderType();
        }

        protected abstract void AddDoneHanlderInternal(TDoneHandler doneHandler);

        private TLoaderType AsLoaderType()
        {
            return (TLoaderType) (object) this;
        }
    }
}
