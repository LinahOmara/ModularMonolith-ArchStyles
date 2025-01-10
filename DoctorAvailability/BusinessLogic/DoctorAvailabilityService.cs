using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.BusinessLogic
{
    // TODO add global exception annotation
    public class DoctorAvailabilityService
    {
        private readonly DoctorAvailabilityRepo _repo;

        public DoctorAvailabilityService()
        {
            _repo = new DoctorAvailabilityRepo();
        }

        public bool AddSlots(DoctorAvailabilityDto availability)
        {
            var availabilityModel = new DoctorAvailabilityModel
            {
                Id = new Guid(),
                DoctorId = availability.DoctorId,
                DoctorName = availability.DoctorName,
                Time = availability.Time,
                IsReserved = availability.IsReserved,
                Cost = availability.Cost
            };

            var (isSucceeded, msg) = IsValidSlot(availabilityModel);
            
            if (!isSucceeded)
            {
                throw new ArgumentException(msg);
            }


            var isAdded = _repo.AddSlot(availabilityModel);

            if (!isAdded)
            {
                throw new Exception("Couldn't add Slot");
            }

            return isAdded;
        }

        public IEnumerable<DoctorAvailabilityDto> GetSlots() 
        {
            return _repo.GetSlots()
                 .Select(s => new DoctorAvailabilityDto
                 {
                     Id = s.Id,
                     DoctorId = s.DoctorId,
                     DoctorName = s.DoctorName,
                     Cost = s.Cost,
                     IsReserved = s.IsReserved,
                     Time = s.Time
                 });
        }

        public IEnumerable<DoctorAvailabilityDto> GetAvailabeSlots()
        {
            return _repo.GetAvailabeSlots()
                .Select(s => new DoctorAvailabilityDto
                {
                    Id = s.Id,
                    DoctorId = s.DoctorId,
                    DoctorName = s.DoctorName,
                    Cost = s.Cost,
                    IsReserved = s.IsReserved,
                    Time = s.Time
                });
        }

        private (bool isSucceeded, string errorMsg) IsValidSlot(DoctorAvailabilityModel availability)
        {
            var existingSlot = GetSlots()
                .Where(s => s.Time == availability.Time);

            if (existingSlot.Count() > 0)
                return (false, "Slot already exist");

            return (true, string.Empty);
        }
    }
}
