
namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities
{
    public class EventBus : IEventBus
    {
       // private readonly Dictionary<Type, List<object>> _handlers = new();
        private readonly Dictionary<Type, List<Type>> _handlers = new();

        private readonly IServiceProvider _serviceProvider;
        public EventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public void  Publish<TEvent>(TEvent @event)
        //{
        //    var eventType = typeof(TEvent);

        //    if (_handlers.ContainsKey(eventType))
        //    {
        //        var handlers = _handlers[eventType];
        //        foreach (var handler in handlers)
        //        {
        //            if (handler is IEventHandler<TEvent> eventHandler)
        //            {
        //                 eventHandler.Handle(@event);
        //            }
        //        }
        //    }
        //}

        public void Publish<TEvent>(TEvent @event)
        {
            var eventType = typeof(TEvent);

            if (_handlers.ContainsKey(eventType))
            {
                var handlerTypes = _handlers[eventType];
                foreach (var handlerType in handlerTypes)
                {
                    var handler = _serviceProvider.GetService(handlerType) as IEventHandler<TEvent>;
                    if (handler != null)
                    {
                         handler.Handle(@event);
                    }
                }
            }
        }

        public void Subscribe<TEvent, IEventHandler>()
        {
            
        var eventType = typeof(TEvent);

            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<Type>();
            }
          var handlerType = typeof(IEventHandler);
            _handlers[eventType].Add(handlerType);
        }
    }
}
