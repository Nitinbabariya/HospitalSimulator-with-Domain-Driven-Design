using System;
using EventFlow.Aggregates;
using Simulator.Domain.Patient.Events;

namespace Simulator.Domain.Patient
{
    internal sealed class PatientState : AggregateState<PatientAggregate, PatientId, PatientState>,
        IApply<FluPatientIsRegistered>,
        IApply<CancerPatientWithHeadAndNeckTopygraphyIsRegistered>,
        IApply<CancerPatientWithBreastTopygraphyIsRegistered>
    {
        public DateTime RegistrationDate { get; private set; }

        public void Apply(FluPatientIsRegistered e)
        {
            RegistrationDate = e.RegistrationDate;
        }

        public void Apply(CancerPatientWithHeadAndNeckTopygraphyIsRegistered e)
        {
            RegistrationDate = e.RegistrationDate;
        }

        public void Apply(CancerPatientWithBreastTopygraphyIsRegistered e)
        {
            RegistrationDate = e.RegistrationDate;
        }
    }
}