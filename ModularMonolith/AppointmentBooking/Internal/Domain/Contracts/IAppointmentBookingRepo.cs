using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Models;


namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Contracts
{
    public interface IAppointmentBookingRepo
    {
        bool AddAppointment(Appointment appointment);
    }
}
