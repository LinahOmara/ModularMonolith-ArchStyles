using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Contracts;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Models;


namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Infrastructure.Repositories
{
    public class AppointmentBookingRepo : IAppointmentBookingRepo
    {
        DBContext _dbContext;
        private static List<AppointmentEntity> _appointments;

        public AppointmentBookingRepo(DBContext dBContext)
        {
            _dbContext = dBContext;
            _appointments = _dbContext.GetAppointmentsEntities();
        }

        public bool AddAppointment(Appointment app)
        {
            var newAppoitment = new AppointmentEntity
            {
                Id = new Guid(),
                AppointmentStatus = app.AppointmentStatus.ToString(),
                PatientId = app.PatientId,
                PatientName = app.PatientName,
                ReservedAt = app.ReservedAt,
                SlotId = app.SlotId,
            };

            _appointments.Add(newAppoitment);
            return true;

        }
    }
}
