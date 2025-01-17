using ModularMonolith_DotNetGirlsGrp.SharedUtilities;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Shared;

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
