namespace De.Kjg.Diversity.Impl.Abstraction.Visuals
{
    public abstract class VisualsAdapter
    {
        protected object Wrapped;

        protected VisualsAdapter(object wrapped)
        {
            Wrapped = wrapped;
        }

        public object GetWrapped()
        {
            return Wrapped;
        }
    }
}
