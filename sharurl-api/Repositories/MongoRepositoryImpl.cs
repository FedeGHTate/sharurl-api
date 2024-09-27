using MongoDB.Bson;
using MongoDB.Driver;
using sharurl_api.Model;

namespace sharurl_api.Repositories
{
    public class MongoRepositoryImpl : IUrlInfoRepository
    {
        private IMongoDatabase _database;
        private IMongoCollection<UrlInfo> _urlInfoDB;

        public MongoRepositoryImpl(IMongoClient client)
        {
            string databaseName = Environment.GetEnvironmentVariable("DB_NAME")!;

            this._database = client.GetDatabase(databaseName);
            this._urlInfoDB = this._database.GetCollection<UrlInfo>(typeof(UrlInfo).Name.ToLower());
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await this._urlInfoDB.DeleteOneAsync(u => u.Id.ToString() == id);

            return result.DeletedCount > 0;
        }

        public async Task<UrlInfo> FindByCodeAsync(string code)
        {

            UrlInfo found = await this._urlInfoDB.Find(u => u.ShortCode == code).FirstOrDefaultAsync();

            return found;
        }

        public async Task<UrlInfo> GetByIdAsync(string id)
        {
            UrlInfo found = await this._urlInfoDB.Find(u => u.Id == new ObjectId(id)).FirstOrDefaultAsync();

            return found;
        }

        public async Task<UrlInfo> SaveAsync(UrlInfo urlInfo)
        {
            await this._urlInfoDB.InsertOneAsync(urlInfo);

            return urlInfo; 
        }

        public async Task<UrlInfo?> UpdateAsync(UrlInfo urlInfo)
        {
            var filter = Builders<UrlInfo>.Filter.Eq(u => u.Id, urlInfo.Id);


            var result = await this._urlInfoDB.ReplaceOneAsync(filter,urlInfo);

            if (result.ModifiedCount == 0)
            {
                return null;
            }

            return urlInfo;
        }

        public async Task<List<UrlInfo>> FindAll()
        {
            return await this._urlInfoDB.Find(u => true).ToListAsync();
        }
    }
}
