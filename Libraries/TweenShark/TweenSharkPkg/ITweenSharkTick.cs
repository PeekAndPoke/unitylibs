namespace De.Kjg.TweenSharkPkg
{
    public interface ITweenSharkTick
    {
        void Run(TweenSharkTickDelegate tickDelegate);
        void Stop();
    }
}
