namespace De.Kjg.Diversity.Interfaces.UXs.Events
{
    public interface IInputEvent : IEvent
    {
        string Content { get; set; }
    }
}
