using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Data
{
    public class DoctorAvailabilityRepo
    {
        private static List<DoctorAvailabilityEntity> _doctorAvailabilities; //TODO Handle in Memory Lists

        public DoctorAvailabilityRepo()
        {
            _doctorAvailabilities ??= new List<DoctorAvailabilityEntity>();
        }

        /// <summary>
        /// Add a new slot
        /// </summary>
        public bool AddSlot(DoctorAvailabilityEntity availability)
        {
            var isSucceeded = false;

            try
            {
                 availability.Id = Guid.NewGuid();   
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
        public IEnumerable<DoctorAvailabilityEntity> GetSlots() 
        {
            return _doctorAvailabilities;
        }

        public IEnumerable<DoctorAvailabilityEntity> GetAvailabeSlots()
        {
            return _doctorAvailabilities.Where(da => da.IsReserved == false);
        }
    }
}
