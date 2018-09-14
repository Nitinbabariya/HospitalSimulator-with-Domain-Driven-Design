using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Simulator.Application.Client;
using Simulator.Application.Client.Doctor;

using Xunit;
using Xunit.Abstractions;


namespace Simulator.Tests.Doctor
{
    public class DoctorTests : DomainTestBase
    {
        public DoctorTests(ITestOutputHelper output) : base(output)
        {

        }

        [Theory]
        [InlineData("", Role.GeneralPractitioner)]
        [InlineData(null, Role.GeneralPractitioner)]
        public void Should_throw_when_adding_a_doctor_with_empty_name(string name, Role role)
        {
            //Arrange

            //Act
            Action action = () => this.Client.AddDoctor(name, role);

            //Assert
            action.Should().Throw<ArgumentNullException>("Because name should not be empty");
        }



        [Theory]
        [InlineData("DoctorWho", Role.GeneralPractitioner)]
        [InlineData("DoctorWho", Role.Oncologist)]
        public void Should_not_throw_when_adding_a_doctor_with_valid_name(string name, Role role)
        {
            //Arrange

            //Act
            Action action = () => this.Client.AddDoctor(name, role);

            //Assert
            action.Should().NotThrow();
        }


        [Theory]
        [InlineData("DoctorWho", Role.Oncologist)]
        [InlineData("DoctorWho", Role.GeneralPractitioner)]
        public void Should_add_doctor_with_a_role(string name, Role role)
        {
            //Arrange
            DoctorModel doctorModel=null;
            Action action = () => doctorModel = this.Client.AddDoctor(name, role);
            action.Invoke();

            //Act
            var result = this.Client.GetDoctorsById(doctorModel.Id.Value);

            //Assert
            result.Should().HaveCount(1,"Only one doctor exists with given doctor id");

            var doctorInResult = result.First();
            doctorInResult.Id.Should().Be(doctorModel.Id);
            doctorInResult.Name.Should().Be(doctorModel.Name);
            doctorInResult.Roles.Should().Contain(role);
        }

        [Theory]
        [InlineData("DoctorWho")]
        public void Should_add_doctor_with_multiple_roles(string name)
        {
            //Arrange
            DoctorModel doctorModel = null;
            doctorModel = this.Client.AddDoctor(name, Role.GeneralPractitioner, Role.Oncologist);

            //Act
            var result = this.Client.GetDoctorsById(doctorModel.Id.Value);

            //Assert
            result.Should().HaveCount(1, "Only one doctor exists with given doctor id");

            var doctorInResult = result.First();
            doctorInResult.Id.Should().Be(doctorModel.Id);
            doctorInResult.Name.Should().Be(doctorModel.Name);
            doctorInResult.Roles.Should().Contain(Role.Oncologist);
            doctorInResult.Roles.Should().Contain(Role.GeneralPractitioner);
        }
    }
}