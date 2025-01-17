using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Shared;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentConfirmation.Application.Notification
{
    public class NotificationService
    {
       
        private ILogger <NotificationService> _logger;    
        public NotificationService(ILogger <NotificationService> log)
        {
            _logger = log;  
                
        }
        public void LogData(AppointmentBookedEvent appointmentBookedEvent)
        {
            _logger.LogInformation($"Appointment for Doctor{appointmentBookedEvent.DoctorName} with patient {appointmentBookedEvent.PatientName} at time {appointmentBookedEvent.AppointmentTime}  has been reserved");

        }
    }
}
