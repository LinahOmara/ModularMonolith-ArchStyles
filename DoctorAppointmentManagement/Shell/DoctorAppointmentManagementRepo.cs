using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Shell
{
    public class DoctorAppointmentManagementRepo : IDoctorAppointmentManagementRepo
    {
        private  List<AppointmentBookingModel> _appointments;
        public DoctorAppointmentManagementRepo()
        {
            _appointments = new List<AppointmentBookingModel> { };
        }

        public IEnumerable<AppointmentBookingModel> GetUpcomingAppointments()
        {
            DateTime getNow =  DateTime.Now;
            IEnumerable<AppointmentBookingModel> upcomingAppointments = _appointments.Where(app=> app.Slot.Time >= getNow);
            return upcomingAppointments;
        }

        public bool UpdateAppointmentStatus(Guid appointmentId ,AppointmentStatus status)
        {
            AppointmentBookingModel? getappointment = _appointments.Where(app => app.Id == appointmentId).FirstOrDefault();
            if (getappointment == null ) 
            {
                throw new ArgumentException("the appointment not found");
            }
            if (getappointment?.AppointmentStatus != AppointmentStatus.Reserved) 
            {
                throw new Exception($"Appointment is already {getappointment?.AppointmentStatus}");
            }
            getappointment.AppointmentStatus = status;
            return true;
        }
    }
}
