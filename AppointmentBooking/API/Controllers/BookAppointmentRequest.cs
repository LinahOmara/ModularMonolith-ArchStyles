using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Core.DomainModels;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.API.Controllers
{
    public class BookAppointmentRequest
    {
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
    }
}
