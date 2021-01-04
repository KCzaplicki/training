using FluentAssertions;
using Xunit;

namespace TrainingFluentAssertions.Tests
{
    public class SensorTests
    {
        private readonly ISensor _sut;

        public SensorTests()
        {
            _sut = new Sensor();
        }

        [Fact]
        public void Should_Pass_When_GetValue_Performed()
        {
            // Act
            var value = _sut.GetValue();

            // Assert
            value.Should().BeInRange(0, 1);
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(1.3)]
        [InlineData(3.1)]
        public void Should_Pass_When_GetValue_WithMinValue_Performed(double minValue)
        {
            // Act
            _sut.MinValue = minValue;
            var value = _sut.GetValue();

            // Assert
            value.Should().BeInRange(minValue, 1 + minValue);
        }
    }
}
