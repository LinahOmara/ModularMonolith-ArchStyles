using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.Data
{
    public class DoctorAvailabilityRepo
    {
        DBContext _dbContext;
        private static List<SlotEntity> _doctorAvailabilities; 

        public DoctorAvailabilityRepo(DBContext dBContext)
        {
            _dbContext = dBContext;
            _doctorAvailabilities = _dbContext.GetDoctorAvailabilitiesEntities();
        }

        public DoctorAvailabilityRepo() //revisit it again
        {
            _dbContext=new DBContext();
            _doctorAvailabilities = _dbContext.GetDoctorAvailabilitiesEntities();

        }
        /// <summary>
        /// Add a new slot
        /// </summary>
        public bool AddSlot(SlotEntity availability)
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
        public IEnumerable<SlotEntity> GetSlots()
        {
            return _doctorAvailabilities;
        }

        public IEnumerable<SlotEntity> GetAvailabeSlots()
        {
            return _doctorAvailabilities.Where(da => da.IsReserved == false);
        }

        public bool ReserveSlot(Guid slotId)
        {
            var slotToUpdate = _doctorAvailabilities.SingleOrDefault(s => s.Id == slotId);
            
            if(slotToUpdate == null)
            {
                throw new ArgumentNullException($"Cant find slot with Id = {slotId}");
            }

            slotToUpdate.IsReserved = true;

            return true;
        }
    }
}
