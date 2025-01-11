using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Shared;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Infrastructure.Gateways
{
    public class DoctorAvailabiltiyGateway
    {
        private IDoctorAvailabiltyApi _doctorAvailabiltyApi;
        public DoctorAvailabiltiyGateway(IDoctorAvailabiltyApi doctorAvailabiltyApi)
        {
            _doctorAvailabiltyApi=doctorAvailabiltyApi;
                
        }
        public IEnumerable<DoctorAvailibleSlotsDto> GetAvailabeSlots()
        {
           return _doctorAvailabiltyApi.GetAvailabeSlots();
        }
    }
}
