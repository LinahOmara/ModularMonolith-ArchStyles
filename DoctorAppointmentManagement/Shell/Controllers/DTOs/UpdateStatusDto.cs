using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Shell.Controllers.DTOs
{
    public class UpdateStatusDto
    {
        public Guid AppointmentId { get; set; }
        public AppointmentStatus Status { get; set; }
         
    }
}
