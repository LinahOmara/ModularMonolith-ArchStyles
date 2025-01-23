namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
        public DateTime ReservedAt { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
