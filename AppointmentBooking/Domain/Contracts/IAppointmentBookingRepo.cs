﻿using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Core.DomainModels;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Domain.Contracts
{
    public interface IAppointmentBookingRepo
    {
      bool AddAppointment(Appointment appointment);
    }
}
