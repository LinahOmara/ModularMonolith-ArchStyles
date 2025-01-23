using ModularMonolith_DotNetGirlsGrp.SharedUtilities;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Shared;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentConfirmation.Application.EventHandlers
{
    public class AppointementBookingHandler : IEventHandler<AppointmentBookedEvent> 
    {
        private ILogger<AppointementBookingHandler> _logger;
        public AppointementBookingHandler(ILogger<AppointementBookingHandler> logger)
        {
            _logger = logger;
        }
        public void  Handle(AppointmentBookedEvent appointmentBookedEvent)
        {
            _logger.LogInformation($"Appointment for Doctor{appointmentBookedEvent.DoctorName} with patient {appointmentBookedEvent.PatientName} at time {appointmentBookedEvent.AppointmentTime}  has been reserved");

        }


    }
}
