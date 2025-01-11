using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;

namespace ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.DomainModels
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid SlotId { get; set; }
        public virtual DoctorAvailabilityEntity Slot { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
        public DateTime ReservedAt { get; set; }
        //Todo Enum should be presisted as string in DB complete, cancle
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
