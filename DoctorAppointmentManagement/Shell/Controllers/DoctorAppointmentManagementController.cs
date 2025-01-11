using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Business;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Shell.Controllers.DTOs;
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.BusinessLogic;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Shell.Controllers
{
    public class DoctorAppointmentManagementController:ControllerBase
    {
        IDoctorAppointmentManagementService _doctorAppointmentManagementService;
        public DoctorAppointmentManagementController(IDoctorAppointmentManagementService service)
        {
            _doctorAppointmentManagementService=service;    


        }

        [HttpGet, Route("api/doctors/appointments")]
        public IActionResult GetUpcomingAppointments()
        {
            var appointments  =_doctorAppointmentManagementService.GetUpcomingAppointments();    
            return Ok(appointments);
        }


        [HttpPut, Route("api/doctors/appointments")]
        public ActionResult<IEnumerable<DoctorAvailabilityDto>> UpdateAppointmentStatus([FromBody] UpdateStatusDto statusDto)
        {
          bool isUpdated=  _doctorAppointmentManagementService.UpdateAppointmentStatus(statusDto.AppointmentId,statusDto.Status);
            return Ok(isUpdated);
        }

    }
}
