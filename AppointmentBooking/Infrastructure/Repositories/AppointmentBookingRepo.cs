using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Domain.Contracts;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Core.DomainModels;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Infrastructure.Repositories
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
