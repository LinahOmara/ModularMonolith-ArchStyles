using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Models;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.API.Controllers
{
    public static class DtoMapper
    {
        public static Appointment ToAppointment(this BookAppointmentRequest request)
        {
            return new Appointment
            {
                SlotId = request.SlotId,
                PatientId = request.PatientId,
                PatientName = request.PatientName,
            };
        }
    }
}
