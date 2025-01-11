using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Domain.Contracts;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Infrastructure.Repositories
{
    public class AppointmentBookingRepo : IAppointmentBookingRepo
    {
        DBContext _dbContext;
        private static List<AppointmentBookingEntity> _appointments;

        public AppointmentBookingRepo(DBContext dBContext)
        {
            _dbContext = dBContext;
            _appointments = _dbContext.GetAppointmentsEntities();

        }
        public bool BookAppointment(Appointment appointment)
        {
            appointment.Slot.IsReserved = true; 
            appointment.ReservedAt = DateTime.Now;
            return true;   //TodDo 

        }
    }
}
