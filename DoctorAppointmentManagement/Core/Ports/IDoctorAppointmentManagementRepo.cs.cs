using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports
{
    public interface IDoctorAppointmentManagementRepo
    {
       IEnumerable<AppointmentBookingModel> GetUpcomingAppointments();
       bool UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status);
    }
}
