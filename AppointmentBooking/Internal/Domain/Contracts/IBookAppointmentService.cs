using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Models;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Contracts
{
    public interface IBookAppointmentService
    {
        bool BookAppointment(Appointment appointment);
    }
}
