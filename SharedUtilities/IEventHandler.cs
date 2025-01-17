namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities
{
    public interface IEventHandler<TEvent>
    {
        void Handle(TEvent @event);
    }
}
