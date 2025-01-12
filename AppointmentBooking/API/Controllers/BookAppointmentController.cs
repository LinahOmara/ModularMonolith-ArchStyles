using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Domain.Contracts;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Core.DomainModels;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.API.Controllers
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
