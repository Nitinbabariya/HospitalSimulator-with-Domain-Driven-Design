using System;
using System.Collections.Generic;
using System.Linq;
using Simulator.Domain.Doctor;
using Simulator.Domain.Treatmentroom;
using Simulator.Query.Doctor;
using Simulator.Query.TreatmentRoom;

namespace Simulator.Domain.ConsultationScheduler.Services
{
    public class ConsultationSchedulerService : IConsultationSchedulerService
    {
        public const int ReservationWindowInDays  = 30;

        private static IEnumerable<DateTime> GetDaysInReservationWindow(DateTime startDate, int days)
        {
            return Enumerable.Range(0, days).Select(d => startDate.AddDays(d));
        }

        //TODO:Instead of using tuple and readModels, create domain entity/value objects and add query to get response using domain entity/value rather than readmodel
        //Domain should not use readmodel directly at all
        public Tuple<DateTime, TreatmentRoomId, DoctorId> GetReservationRequest(IReadOnlyCollection<TreatmentRoomReadModel> treatmentRooms, IReadOnlyCollection<DoctorReadModel> doctors)
        {
            var days = GetDaysInReservationWindow(DateTime.UtcNow.Date, ReservationWindowInDays);

            var treatmentRoomAvailability = from treatmentRoom in treatmentRooms.AsParallel()
                                            from day in days
                                            where !treatmentRoom.Reservations.Contains(day)
                                            select new { treatmentRoom.Id, day };

            var doctorAvailability = from doctor in doctors.AsParallel()
                                     from day in days
                                     where !doctor.Reservations.Contains(day)
                                     select new { doctor.Id, day };

            var availableDays = from room in treatmentRoomAvailability
                                from doctor in doctorAvailability
                                where room.day == doctor.day
                                select room.day;

            var firstAvailableDay = availableDays.Min();

            var treatmentRoomId = treatmentRoomAvailability.FirstOrDefault(x => x.day == firstAvailableDay).Id;

            //TODO:Handle if there is no treatmentroom available for consultation

            var doctorId = doctorAvailability.FirstOrDefault(x => x.day == firstAvailableDay).Id;
            //TODO:Handle If there is no doctor is not available

            return new Tuple<DateTime, TreatmentRoomId, DoctorId>(firstAvailableDay, treatmentRoomId, new DoctorId(doctorId));
        }
    }
}