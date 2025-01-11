using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Domain.Contracts
{
    public interface IAppointmentBookingRepo
    {

      bool  BookAppointment(Appointment appointment);
    }
}
