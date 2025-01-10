using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.BusinessLogic;
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Controller
{
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly DoctorAvailabilityService _service;

        public DoctorAvailabilityController()
        {
            _service = new DoctorAvailabilityService();
        }

        [HttpPost, Route("api/doctors/availabilities")]
        public IActionResult AddSlot ([FromBody] DoctorAvailabilityDto doctorAvailability)
        {
            _service.AddSlots(doctorAvailability);
            return Ok();
        }


        [HttpGet, Route("api/doctors/availabilities")]
        public ActionResult<IEnumerable<DoctorAvailabilityDto>> GetSlot()
        {
            var slots = _service.GetSlots();
            return Ok(slots);
        }

        //Debug
    }
}
