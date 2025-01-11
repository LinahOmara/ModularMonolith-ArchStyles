﻿using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Shell.Repositories
{
    public class DoctorAppointmentManagementRepo : IDoctorAppointmentManagementRepo
    {

        DBContext _dbContext;
         private static List<AppointmentBookingEntity> _appointments;
        //public DoctorAppointmentManagementRepo()
        //{
        //    _appointments = new List<AppointmentBookingEntity> { };
        //}

        public DoctorAppointmentManagementRepo(DBContext dBContext)
        {
            _dbContext = dBContext;
            _appointments=_dbContext.GetAppointmentsEntities(); 

        }
        public IEnumerable<Appointment> GetUpcomingAppointments()
        {
            DateTime getNow = DateTime.Now;
            IEnumerable<AppointmentBookingEntity> upcomingAppointments = _appointments.Where(app => app.Slot.Time >= getNow);
            return upcomingAppointments.Select(app=>new Appointment
            {
                Id= app.Id, 
                AppointmentStatus= Enum.Parse<AppointmentStatus>(app.AppointmentStatus),
                PatientId =app.PatientId,
                PatientName=app.PatientName,
                ReservedAt=app.ReservedAt,  
                SlotId=app.SlotId,  
                Slot= app.Slot
            });
        }

        public bool UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status)
        {
            AppointmentBookingEntity? appointment = _appointments.Where(app => app.Id == appointmentId).FirstOrDefault();
            if (appointment == null)
            {
                throw new ArgumentException("the appointment not found");
            }
            if (appointment?.AppointmentStatus != AppointmentStatus.Reserved.ToString())
            {
                throw new Exception($"Appointment is already {appointment?.AppointmentStatus}");
            }
            appointment.AppointmentStatus = status.ToString();
            return true;
        }
    }
}
