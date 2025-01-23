using System;

namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities
{
  
    public interface IEventBus
    {
        public void Subscribe<TEvent, IEventHandler>();
        public void Publish<TEvent>(TEvent @event);
    }
}
