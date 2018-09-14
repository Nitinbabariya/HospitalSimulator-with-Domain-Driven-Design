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
    public class ConsultationSchedulerServiceTests : DomainTestBase
    {
        public ConsultationSchedulerServiceTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Should_have_reservation_window_of_30_Days()
        {
            ConsultationSchedulerService.ReservationWindowInDays.Should().Be(30);
        }

        //TODO: Add unit tests on the logic to calculate the earliest consultation day based on the availability of required Treatmentroom and doctor
        [Fact (Skip = "Skipping due to time constraint")]
        public void GetReservationRequest_should_return_earliest_Day_for_consultation()
        {
            Assert.True(false);
        }
    }
}