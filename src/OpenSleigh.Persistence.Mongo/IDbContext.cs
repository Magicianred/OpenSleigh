using MongoDB.Driver;

namespace OpenSleigh.Persistence.Mongo
{
    public interface IDbContext
    {
        IMongoCollection<Entities.SagaState> SagaStates { get; }
    }
}