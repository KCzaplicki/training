using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;

namespace TrainingAutoFixture.Tests
{
    public class CustomParserWrapperTests
    {
        [Fact]
        public void Should_Return_ParsedValue_When_Passed_Model()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var customParser = fixture.Create<ICustomParser>();
            var model = fixture.Create<DataModel>();
            var sut = new CustomParserWrapper(customParser);
            
            //Act
            var result = sut.Parse(model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal($"{nameof(DataModel)}: []", result);
        }

        [Theory, AutoMoqData]
        public void Should_Return_ParsedValue_When_Passed_Model_AutoData(ICustomParser customParser, DataModel model)
        {
            //Arrange
            var sut = new CustomParserWrapper(customParser);

            //Act
            var result = sut.Parse(model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal($"{nameof(DataModel)}: []", result);
        }
    }
}
