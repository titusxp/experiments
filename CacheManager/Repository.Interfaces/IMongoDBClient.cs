using MongoDB.Driver;

namespace Repository.Interfaces
{
    public interface IMongoDBClient<T> : MongoDB.Driver.IMongoClient
    {
        string DatabaseName { get; }
        IMongoCollection<T> Collection { get; }
    }
}
