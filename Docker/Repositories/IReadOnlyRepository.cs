using System.Collections.Generic;

namespace TrainingDocker.Repositories
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IEnumerable<T> Get();

        T Get(int id);
    }
}
