namespace TrainingAutoFixture
{
    public class CustomParser : ICustomParser
    {
        public string Parse(DataModel dataModel) => $"{dataModel.Order}:{dataModel.Key}:{dataModel.Value}";
    }
}
