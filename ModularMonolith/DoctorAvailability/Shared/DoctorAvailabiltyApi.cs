
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Shared
{
    public class DoctorAvailabiltyApi : IDoctorAvailabiltyApi
    {
        private readonly DoctorAvailabilityRepo _doctorAvailabilityRepo;

        public DoctorAvailabiltyApi(DoctorAvailabilityRepo doctorAvailabilityRepo) // Should be interface if this is a clean arch 
        {
            _doctorAvailabilityRepo = doctorAvailabilityRepo;
        }

        public IEnumerable<SlotsDto> GetAvailabeSlots()
        {
            return _doctorAvailabilityRepo.GetAvailabeSlots().Select(avs => avs.ToDto());
        }

        public bool ReserveSlot(Guid slotId)
        {
            return _doctorAvailabilityRepo.ReserveSlot(slotId);
        }
    }
}
