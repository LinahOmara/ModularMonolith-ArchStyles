using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports
{
    public interface IDoctorAppointmentManagementRepo
    {
       IEnumerable<Appointment> GetUpcomingAppointments();
       bool UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status);
    }
}
