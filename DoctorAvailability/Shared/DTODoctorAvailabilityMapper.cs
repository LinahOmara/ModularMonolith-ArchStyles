using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Shared
{
    public static class DTODoctorAvailabilityMapper
    {
        public static SlotsDto ToDto (this SlotEntity entity)
        {
            return new SlotsDto 
            {
                Id = entity.Id,
                Cost = entity.Cost,
                DoctorId = entity.DoctorId,
                DoctorName = entity.DoctorName,
                IsReserved = entity.IsReserved,
                Time = entity.Time
            };
        }
    }
}
