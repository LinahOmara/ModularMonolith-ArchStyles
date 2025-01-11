namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data
{
    public class DoctorAvailabilityEntity
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Time { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }

    }
}
