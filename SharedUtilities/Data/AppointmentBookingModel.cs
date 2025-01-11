namespace ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data
{
    public class AppointmentBookingModel
    {
        public Guid Id { get; set; }
        public Guid SlotId { get; set; }
        public virtual DoctorAvailabilityModel Slot { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }

        public DateTime ReservedAt { get; set; }
        public string AppointmentStatus {get;set;}
    }
}


