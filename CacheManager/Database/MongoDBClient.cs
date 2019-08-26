using MongoDB.Driver;

namespace Database
{
    public class MongoDBClient<T> : MongoClient, Repository.Interfaces.IMongoDBClient<T>
    {
        public MongoDBClient() : base("mongodb://localhost")
        {
            if (_database == null)
            {
                _database = this.GetDatabase(DatabaseName);
            }
        }
        public string DatabaseName => DatabaseNameStatic;
        public static string DatabaseNameStatic { get { return "CacheManager"; } }

        private static IMongoDatabase _database;

        public IMongoCollection<T> Collection  {
            get
            {
                var collectionName = typeof(T).Name;
                var c = _database?.GetCollection<T>(collectionName);
                return c;
            }
        }
    }
}
