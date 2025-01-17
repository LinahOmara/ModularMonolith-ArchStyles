
namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.API.Controllers
{
    public class BookAppointmentRequest
    {
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
    }
}
