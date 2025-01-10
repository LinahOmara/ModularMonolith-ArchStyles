using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports;

using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Shell;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Business
{
    public class DoctorAppointmentManagementService
    {
        private IDoctorAppointmentManagementRepo _repo;
        public DoctorAppointmentManagementService()
        {
            _repo = new DoctorAppointmentManagementRepo();
        }
        //Todo change AppointmentBookingModel  with proper Dto
        public IEnumerable<AppointmentBookingModel> GetUpcomingAppointments()
        {
            return _repo.GetUpcomingAppointments();
        }
        public bool UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status)
        {
            return _repo.UpdateAppointmentStatus(appointmentId, status);
        }
    }
}
