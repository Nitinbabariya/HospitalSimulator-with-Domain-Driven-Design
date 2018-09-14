using System;
using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;

namespace Simulator.Tests.TreatmentMachine
{
    public class TreatmentMachineWithAdvancedCapacityTests : DomainTestBase
    {
        public TreatmentMachineWithAdvancedCapacityTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_throw_when_adding_a_machine_with_empty_name(string name)
        {
            //Arrange

            //Act
            Action action = () => this.Client.AddMachineWithAdvancedCapability(name);

            //Assert
            action.Should().Throw<ArgumentNullException>("Because name should not be empty");
        }


        [Theory]
        [InlineData("MachineA")]
        public void Should_not_throw_when_adding_a_machine_with_valid_name(string name)
        {
            //Arrange

            //Act
            Action action = () => this.Client.AddMachineWithAdvancedCapability(name);

            //Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData("MachineA")]

        public void Should_throw_when_adding_a_machine_with_duplicate_name(string machineA)
        {
            //Arrange
            //Arrange
            this.Client.AddMachineWithAdvancedCapability(machineA);

            //Act
            Action addMachineWithDuplicateName = () => this.Client.AddMachineWithAdvancedCapability(machineA);

            //Assert
            addMachineWithDuplicateName.Should().Throw<EventFlow.Exceptions.DomainError>();
        }


        [Theory]
        [InlineData("MachineA", "MachineB")]
        public void Should_add_machines_with_unique_names(string machineA, string machineB)
        {
            //Arrange
            this.Client.AddMachineWithAdvancedCapability(machineA);
            this.Client.AddMachineWithAdvancedCapability(machineB);

            //Act
            var result = this.Client.GetAllTreatmentMachines();

            //Assert
            result.Select(x=>x.HasAdvancedCapability).Should().HaveCount(2, "Two machines are created with unique names");
        }
    }
}