using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumFund.Data
{
    public class Supervisor
    {
        public Supervisor(string fIO)
        {
            FIO = fIO;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string FIO { get; set; }

        public async static void AddSupVis(Supervisor sv)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Supervisor>("supervisors");
            await collection.InsertOneAsync(sv);

        }

        public async static Task<List<Supervisor>> GetSupVis()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Supervisor>("supervisors");
            return collection.Find(x => true).ToList();
        }
    }
}
