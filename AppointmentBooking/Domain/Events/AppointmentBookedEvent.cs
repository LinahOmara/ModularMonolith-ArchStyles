namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Domain.Events
{
    public class AppointmentBookedEvent
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}
