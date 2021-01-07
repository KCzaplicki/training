using AutoFixture;
using AutoFixture.Xunit2;
using Xunit;

namespace TrainingAutoFixture.Tests
{
    public class CustomParserTests
    {
        private readonly ICustomParser _sut = new CustomParser();

        [Fact]
        public void Should_Return_ParsedValue_When_Passed_Model()
        {
            //Arrange
            var fixture = new Fixture();
            var model = fixture.Create<DataModel>();

            //Act
            var result = _sut.Parse(model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal($"{model.Order}:{model.Key}:{model.Value}", result);
        }

        [Fact]
        public void Should_Return_ParsedValue_When_Passed_ManyModels()
        {
            //Arrange
            var fixture = new Fixture();
            var modelCollection = fixture.CreateMany<DataModel>();

            foreach (var model in modelCollection)
            {
                //Act
                var result = _sut.Parse(model);

                //Assert
                Assert.NotNull(result);
                Assert.Equal($"{model.Order}:{model.Key}:{model.Value}", result);
            }
        }

        [Fact]
        public void Should_Return_ParsedValue_When_Passed_BuildModel()
        {
            //Arrange
            var fixture = new Fixture();
            var model = fixture.Build<DataModel>()
                .Without(x => x.Order)
                .Create();

            //Act
            var result = _sut.Parse(model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal($"{model.Order}:{model.Key}:{model.Value}", result);
            Assert.Equal(0, model.Order);
        }

        [Theory, AutoData]
        public void Should_Return_ParsedValue_When_Passed_Model_AutoData(string key, string value, int order)
        {
            //Arrange
            var model = new DataModel
            {
                Key = key,
                Value = value,
                Order = order
            };

            //Act
            var result = _sut.Parse(model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal($"{order}:{key}:{value}", result);
        }

        [Theory, AutoData]
        public void Should_Return_ParsedValue_When_Passed_Model_AutoDataObject(DataModel model)
        {
            //Act
            var result = _sut.Parse(model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal($"{model.Order}:{model.Key}:{model.Value}", result);
        }

        [Theory]
        [InlineAutoData("key1")]
        [InlineAutoData("key2", "value2")]
        [InlineAutoData("key3", "value3", 1)]
        public void Should_Return_ParsedValue_When_Passed_Model_InlineAutoData(string key, string value, int order)
        {
            //Arrange
            var model = new DataModel
            {
                Key = key,
                Value = value,
                Order = order
            };

            //Act
            var result = _sut.Parse(model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal($"{order}:{key}:{value}", result);
        }
    }
}
