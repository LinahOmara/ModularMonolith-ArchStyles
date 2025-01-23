namespace ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Shared
{
    public class SlotsDto
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Time { get; set; }
        public bool IsReserved { get; set; } = false;
        public decimal Cost { get; set; }
    }
}
