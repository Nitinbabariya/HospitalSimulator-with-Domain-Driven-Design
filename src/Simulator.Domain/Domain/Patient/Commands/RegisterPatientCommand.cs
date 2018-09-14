using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using Simulator.Domain.Common;

namespace Simulator.Domain.Patient.Commands
{
    public abstract class RegisterPatientCommand:Command<PatientAggregate,PatientId>
    {
        public Name Name { get; private set; }
        protected RegisterPatientCommand(PatientId aggregateId, Name name) : base(aggregateId)
        {
            Name = name;
        }
    }
}