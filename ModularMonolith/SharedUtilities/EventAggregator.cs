using Microsoft.Extensions.DependencyInjection;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Shared;
using ModularMonolith_DotNetGirlsGrp.AppointmentConfirmation.Application.EventHandlers;

namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities
{
    public class EventAggregator
    {
        private readonly IEventBus _eventBus;
        public EventAggregator(IEventBus eventBus )
        {
            _eventBus = eventBus;

           // AppointementBookingHandler getAppointementBookingHandler = serviceProvider.GetRequiredService<AppointementBookingHandler>();
            _eventBus.Subscribe<AppointmentBookedEvent, AppointementBookingHandler>();
        }


    }
}
