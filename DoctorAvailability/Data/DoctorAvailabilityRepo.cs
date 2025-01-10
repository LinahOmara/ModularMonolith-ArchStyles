namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Data
{
    public class DoctorAvailabilityRepo
    {
        private static List<DoctorAvailabilityModel> _doctorAvailabilities; //TODO Handle in Memory Lists

        public DoctorAvailabilityRepo()
        {
            _doctorAvailabilities = new List<DoctorAvailabilityModel>();
        }

        /// <summary>
        /// Add a new slot
        /// </summary>
        public bool AddSlot(DoctorAvailabilityModel availability)
        {
            var isSucceeded = false;

            try
            {
                _doctorAvailabilities.Add(availability);
                isSucceeded = true;
            }
            catch (Exception)
            {
                isSucceeded = false;
            }

            return isSucceeded;
        }

        /// <summary>
        /// Return doctor Slots
        /// </summary>
        public IEnumerable<DoctorAvailabilityModel> GetSlots() 
        {
            return _doctorAvailabilities;
        }

        public IEnumerable<DoctorAvailabilityModel> GetAvailabeSlots()
        {
            return _doctorAvailabilities.Where(da => da.IsReserved == false);
        }
    }
}
