namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data
{
    public class DBContext
    {
        private static List<AppointmentEntity> _appointments;
        private static List<SlotEntity> _doctorAvailabilities;

        public DBContext()
        {
            _appointments ??= new List<AppointmentEntity> { };
            _doctorAvailabilities ??= new List<SlotEntity>();
        }

        public List<AppointmentEntity> GetAppointmentsEntities() {  return _appointments; }  
        public List<SlotEntity> GetDoctorAvailabilitiesEntities() { return _doctorAvailabilities; }

    }
}
