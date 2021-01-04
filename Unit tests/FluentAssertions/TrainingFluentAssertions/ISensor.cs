namespace TrainingFluentAssertions
{
    public interface ISensor
    {
        double MinValue { get; set; }
        double GetValue();
    }
}