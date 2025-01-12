using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Core.DomainModels;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Domain.Contracts
{
    public interface IBookAppointmentService
    {
      bool BookAppointment(Appointment appointment);
    }
}
