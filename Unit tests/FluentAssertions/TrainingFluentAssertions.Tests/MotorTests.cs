using FluentAssertions;
using System;
using Xunit;

namespace TrainingFluentAssertions.Tests
{
    public class MotorTests
    {
        private readonly IMotor _sut;

        public MotorTests()
        {
            _sut = new Motor();
        }

        [Fact]
        public void Should_Pass_When_Start_Performed()
        {
            // Act
            _sut.Start();
        }

        [Fact]
        public void Should_Throw_When_Start_PerformedTwice()
        {
            // Act
            _sut.Start();
            Action action = () => _sut.Start();

            // Assert<
            action.Should().Throw<InvalidOperationException>().WithMessage("Start can't be performed");
        }

        [Fact]
        public void Should_Pass_When_Stop_Performed()
        {
            // Act
            _sut.Start();
            _sut.Stop();
        }

        [Fact]
        public void Should_Throw_When_Stop_PerformedTwice()
        {
            // Act
            Action action = () => _sut.Stop();

            // Assert
            action.Should().Throw<InvalidOperationException>().WithMessage("Stop can't be performed");
        }
    }
}
