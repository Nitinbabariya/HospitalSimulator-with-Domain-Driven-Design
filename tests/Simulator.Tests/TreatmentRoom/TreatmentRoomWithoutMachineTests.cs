using System;
using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;

namespace Simulator.Tests.TreatmentRoom
{
    public class TreatmentRoomWithoutMachineTests: DomainTestBase
    {
        public TreatmentRoomWithoutMachineTests(ITestOutputHelper output) : base(output)
        {

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_throw_when_adding_a_room_with_empty_name(string name)
        {
            //Arrange

            //Act
            Action action = () => this.Client.AddTreatmentRoom(name);

            //Assert
            action.Should().Throw<ArgumentNullException>("Because name should not be empty");
        }


        [Theory]
        [InlineData("RoomA")]
        public void Should_not_throw_when_adding_a_room_with_valid_name(string name)
        {
            //Arrange

            //Act
            Action action = () => this.Client.AddTreatmentRoom(name);

            //Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData("RoomA")]

        public void Should_throw_when_adding_a_room_with_duplicate_name(string roomA)
        {
            //Arrange
            //Arrange
            this.Client.AddTreatmentRoom(roomA);

            //Act
            Action addRoomWithDuplicateName = () => this.Client.AddTreatmentRoom(roomA);

            //Assert
            addRoomWithDuplicateName.Should().Throw<EventFlow.Exceptions.DomainError>();
        }


        [Theory]
        [InlineData("RoomA", "RoomB")]
        public void Should_add_rooms_with_unique_names(string roomA, string roomB)
        {
            //Arrange
            this.Client.AddTreatmentRoom(roomA);
            this.Client.AddTreatmentRoom(roomB);

            //Act
            var result = this.Client.GetAllTreatmentRooms();

            //Assert
            result.Should().HaveCount(2, "Two rooms are created with unique names");
        }
    }
}