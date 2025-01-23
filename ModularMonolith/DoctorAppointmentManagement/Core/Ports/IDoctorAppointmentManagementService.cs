using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports
{
    public interface IDoctorAppointmentManagementService
    {
        IEnumerable<Appointment> GetUpcomingAppointments();
        bool UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status);
    }
}
