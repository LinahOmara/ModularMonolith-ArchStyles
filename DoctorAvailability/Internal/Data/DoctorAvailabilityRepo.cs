using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.Data
{
    public class DoctorAvailabilityRepo
    {
        DBContext _dbContext;
        private static List<DoctorAvailabilityEntity> _doctorAvailabilities; 

        //public DoctorAvailabilityRepo()
        //{
        //    _doctorAvailabilities ??= new List<DoctorAvailabilityEntity>();
        //}

        public DoctorAvailabilityRepo(DBContext dBContext)
        {
            _dbContext = dBContext;
            _doctorAvailabilities=_dbContext.GetDoctorAvailabilitiesEntities();
        }
        public DoctorAvailabilityRepo() //revisit it again
        {
            _dbContext=new DBContext();
            _doctorAvailabilities = _dbContext.GetDoctorAvailabilitiesEntities();
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
