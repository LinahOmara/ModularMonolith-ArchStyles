using System;

namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities
{
  
    public interface IEventBus
    {
        public void Subscribe<TEvent>(IEventHandler<TEvent> handler);
        public  Task Publish<TEvent>(TEvent @event);
    }
}
