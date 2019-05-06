namespace De.Kjg.TweenSharkPkg.Tweening.Accessor
{
    interface IAccessor<TValueType>
    {
        TValueType GetValue();
        void SetValue(TValueType value);
    }
}
