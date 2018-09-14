using System;
using System.Linq;

using FluentAssertions;

using Simulator.Application.Client;

using Xunit;
using Xunit.Abstractions;

namespace Simulator.Tests.TreatmentRoom
{
    public class TreatmentRoomWithMachineTests: DomainTestBase
    {
        public TreatmentRoomWithMachineTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("RoomA", "MachineA")]
        public void Should_add_a_room_with_a_machine(string roomA, string machineA)
        {
            //Arrange
            var machineInEvenStore = this.Client.AddMachineWithSimpleCapability(machineA);

            //Act
            var roomFromEventStore = this.Client.AddTreatmentRoom(roomA, machineA);

            //Assert
            roomFromEventStore.Should().NotBeNull();
            roomFromEventStore.TreatmentMachineId.Should().Be(machineInEvenStore.Id.Value);
        }
    }
}