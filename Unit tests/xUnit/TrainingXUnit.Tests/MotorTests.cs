using System;
using Xunit;

namespace TrainingXUnit.Tests
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
            var ex = Assert.Throws<InvalidOperationException>(() => _sut.Start());

            // Assert
            Assert.NotNull(ex);
            Assert.Equal("Start can't be performed", ex.Message);
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
            var ex = Assert.Throws<InvalidOperationException>(() => _sut.Stop());

            // Assert
            Assert.NotNull(ex);
            Assert.Equal("Stop can't be performed", ex.Message);
        }
    }
}
