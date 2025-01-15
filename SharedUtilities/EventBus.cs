
namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<object>> _handlers = new();
        public async Task Publish<TEvent>(TEvent @event)
        {
            var eventType = typeof(TEvent);

            if (_handlers.ContainsKey(eventType))
            {
                var handlers = _handlers[eventType];
                foreach (var handler in handlers)
                {
                    if (handler is IEventHandler<TEvent> eventHandler)
                    {
                        await eventHandler.Handle(@event);
                    }
                }
            }
        }
            

        public void Subscribe<TEvent>(IEventHandler<TEvent> handler)
        {
            
        var eventType = typeof(TEvent);

            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<object>();
            }

            _handlers[eventType].Add(handler);
        }
    }
}
