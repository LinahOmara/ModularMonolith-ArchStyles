using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.BusinessLogic;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.Controller
{
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly DoctorAvailabilityService _service;

        public DoctorAvailabilityController()
        {
            _service = new DoctorAvailabilityService();
        }

        [HttpPost, Route("api/doctors/availabilities")]
        public IActionResult AddSlot([FromBody] DoctorAvailabilityDto doctorAvailability)
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

        [HttpGet, Route("api/doctors/availabileSlots/")]
        public ActionResult<IEnumerable<DoctorAvailabilityDto>> GetAvailabeSlot()
        {
            var availableSlots = _service.GetAvailabeSlots();
            return Ok(availableSlots);
        }

    }
}
