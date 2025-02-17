﻿using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Shared;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Infrastructure.Gateways
{
    public class DoctorAvailabiltiyGateway
    {
        private IDoctorAvailabiltyApi _doctorAvailabiltyApi;

        public DoctorAvailabiltiyGateway(IDoctorAvailabiltyApi doctorAvailabiltyApi)
        {
            _doctorAvailabiltyApi = doctorAvailabiltyApi;

        }

        public IEnumerable<SlotsDto> GetAvailabeSlots()
        {
            return _doctorAvailabiltyApi.GetAvailabeSlots();
        }

        public bool ReserveSlot(Guid slotId)
        {
            return _doctorAvailabiltyApi.ReserveSlot(slotId);
        }

    }
}
