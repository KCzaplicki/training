using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TrainingFluentAssertions.Tests
{
    public class EngineTests
    {
        private readonly Mock<IMotor> _motorMock;
        private readonly Mock<ISensor> _sensorMock;
        private readonly Engine _sut;

        public EngineTests()
        {
            _motorMock = new Mock<IMotor>();
            _sensorMock = new Mock<ISensor>();

            _sut = new Engine(_motorMock.Object, _sensorMock.Object);
        }

        [Fact]
        public async Task Should_Pass_When_Run_Performed()
        {
            // Act
            var (success, result) = await _sut.Run();

            // Assert
            _motorMock.Verify(x => x.Start());
            _sensorMock.Verify(x => x.GetValue());
            _motorMock.Verify(x => x.Stop());

            success.Should().BeTrue();
            result.Should().BeInRange(0, 1);
        }

        [Theory]
        [InlineData(0.3)]
        [InlineData(0.35)]
        [InlineData(0.5)]
        public async Task Should_Pass_When_SetSensorMinValue_Performed(double minValue)
        {
            // Arrange
            _sensorMock.Setup(x => x.GetValue()).Returns(minValue);

            // Act
            _sut.SetSensorMinValue(minValue);
            var (success, result) = await _sut.Run();

            // Assert
            _sensorMock.VerifySet(x => x.MinValue = minValue, Times.Once);
            success.Should().BeTrue();
            result.Should().BeInRange(minValue, 1);
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public async Task Should_Throw_When_SetSensorMinValue_OutOfRange(double minValue)
        {
            // Act
            Action action = () => _sut.SetSensorMinValue(minValue);

            // Assert
            _sensorMock.VerifySet(x => x.MinValue = minValue, Times.Never);

            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Specified argument was out of the range of valid values. (Parameter 'value out of range 0-1.')");
        }
    }
}
