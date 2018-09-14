using System;
using System.Collections.Generic;

using Simulator.Domain.Doctor;
using Simulator.Domain.Treatmentroom;
using Simulator.Query.Doctor;
using Simulator.Query.TreatmentRoom;

namespace Simulator.Domain.ConsultationScheduler.Services
{
    public interface IConsultationSchedulerService
    {
        //TODO:Instead of using tuple and readModels, create domain entity/value objects and add query to get response using domain entity/value rather than readmodel
        //Domain should not use readmodel directly at all
        Tuple<DateTime, TreatmentRoomId, DoctorId> GetReservationRequest(IReadOnlyCollection<TreatmentRoomReadModel> treatmentRooms, IReadOnlyCollection<DoctorReadModel> doctors);
    }
}