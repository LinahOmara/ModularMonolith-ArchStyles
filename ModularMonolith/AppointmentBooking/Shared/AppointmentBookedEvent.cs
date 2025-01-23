namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Shared
{
    public class AppointmentBookedEvent
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}
