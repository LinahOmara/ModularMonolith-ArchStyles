using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Domain.Events;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentConfirmation.Application.EventHandlers
{
    public class AppointementBookingHandler : IEventHandler<AppointmentBookedEvent> //TODO find correct place for AppointmentBookedEvent as it's coupled now
    {
        public Task Handle(AppointmentBookedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
