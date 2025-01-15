namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities
{
    public interface IEventHandler<TEvent>
    {
        Task Handle(TEvent @event);
    }
}
