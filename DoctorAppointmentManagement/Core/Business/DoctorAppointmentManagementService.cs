using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports;

 
namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Business
{
    public class DoctorAppointmentManagementService: IDoctorAppointmentManagementService
    {
        private IDoctorAppointmentManagementRepo _repo;
        public DoctorAppointmentManagementService(IDoctorAppointmentManagementRepo repo)
        {
            _repo = repo;
        }
         
        public IEnumerable<Appointment> GetUpcomingAppointments()
        {
            return _repo.GetUpcomingAppointments();
        }
        public bool UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status)
        {
            return _repo.UpdateAppointmentStatus(appointmentId, status);
        }
    }
}
