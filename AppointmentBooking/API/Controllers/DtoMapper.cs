using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Core.DomainModels;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.API.Controllers
{
    public static class DtoMapper
    {
        public static Appointment ToAppointment (this BookAppointmentRequest request)
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
