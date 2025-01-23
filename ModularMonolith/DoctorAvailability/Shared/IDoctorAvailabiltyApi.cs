using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.BusinessLogic;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Shared
{
    public interface IDoctorAvailabiltyApi
    {
        public IEnumerable<SlotsDto> GetAvailabeSlots();
        public bool ReserveSlot(Guid slotId);
    }
}
