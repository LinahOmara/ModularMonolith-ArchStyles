using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Contracts;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.API.Controllers
{
    public class BookAppointmentController : ControllerBase
    {
        private readonly IBookAppointmentService _service;

        public BookAppointmentController(IBookAppointmentService service)
        {
            _service = service;
        }

        [HttpPost, Route("api/appointments/book")]
        public bool BookAppointment([FromBody] BookAppointmentRequest appointmentRequest)
        {
            return _service.BookAppointment(appointmentRequest.ToAppointment());
        }
    }
}
