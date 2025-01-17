using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Contracts;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Models;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Infrastructure.Gateways;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Shared;

namespace ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Application
{
    public class BookAppointmentService : IBookAppointmentService
    {
        private readonly IAppointmentBookingRepo _repo;
        private readonly DoctorAvailabiltiyGateway _doctorAvailabiltiyGateway;
        private readonly IEventBus _eventBus;

        public BookAppointmentService(IAppointmentBookingRepo repo,
                                    DoctorAvailabiltiyGateway doctorAvailabiltiyGateway,
                                     IEventBus eventBus)
        {
            _repo = repo;
            _doctorAvailabiltiyGateway = doctorAvailabiltiyGateway;
            _eventBus = eventBus;

        }

        public bool BookAppointment(Appointment appointment)
        {
            // TODO: Check that the slot is not reserved already 
            var availableSlotes = _doctorAvailabiltiyGateway.GetAvailabeSlots();

            var firstAvail = availableSlotes.Where(x => x.Id == appointment.SlotId).FirstOrDefault();
            if (firstAvail != null && !firstAvail.IsReserved)
            {
                // add appointment data
                bool appAdded = AddBookedAppointment(appointment);

                // update slot data
                bool slotUpdated = UpdateSlotForBookedAppointment(appointment);
                //publish booking event for confiramtion
                _eventBus.Publish<AppointmentBookedEvent>(new AppointmentBookedEvent 
                { 
                    PatientName = appointment.PatientName!=null? appointment.PatientName:"",
                    AppointmentTime =appointment.ReservedAt,
                    DoctorName = firstAvail.DoctorName
                });
                return appAdded && slotUpdated;
            }

            else throw new Exception($"Slot is already reserved {appointment.SlotId}");
        }

        private bool UpdateSlotForBookedAppointment(Appointment appointment)
        {
            var slotUpdated = _doctorAvailabiltiyGateway.ReserveSlot(appointment.SlotId);
            return slotUpdated;
        }

        private bool AddBookedAppointment(Appointment appointment)
        {
            appointment.Id = new Guid();
            appointment.ReservedAt = DateTime.Now;
            appointment.AppointmentStatus = AppointmentStatus.Reserved;

            var appAdded = _repo.AddAppointment(appointment);
            return appAdded;
        }
    }
}
