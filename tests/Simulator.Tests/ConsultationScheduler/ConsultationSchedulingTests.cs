using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Simulator.Domain.ConsultationScheduler.Services;
using Simulator.Query.TreatmentRoom;

using Xunit;
using Xunit.Abstractions;

namespace Simulator.Tests.ConsultationScheduler
{
    public class ConsultationSchedulingTests : DomainTestBase
    {
        public ConsultationSchedulingTests(ITestOutputHelper output) : base(output)
        {
        }

        //TODO: Add tests to assert that a consultation is booked on earliest day for given patient considering
        //following business rules

        //A consultation must not be booked on the same day as
        //A consultation may not be scheduled on the same day as the patient is registered
        //Cancer patients with HeadAndNeck topology should meet oncologiest with in a room having a machine with advanced capacity
        //Cancer patients with Breast topology should meet oncologiest with in a room having a machine with advanced capacity or simple capacity
        //Flue with should meet General Practitioners in any treatmentroom, (presence of treatment machine is not required)
    }
}