namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data
{
    public class DBContext
    {
        private static List<AppointmentBookingEntity> _appointments;
        private static List<DoctorAvailabilityEntity> _doctorAvailabilities;

        public DBContext()
        {
            _appointments = new List<AppointmentBookingEntity> { };
            _doctorAvailabilities ??= new List<DoctorAvailabilityEntity>();
        }

        public List<AppointmentBookingEntity> GetAppointmentsEntities() {  return _appointments; }  
        public List<DoctorAvailabilityEntity> GetDoctorAvailabilitiesEntities() { return _doctorAvailabilities; }

    }
}
