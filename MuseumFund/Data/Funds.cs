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
    public class Funds
    {
        public Funds(string name)
        {
            Name = name;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }


        public async static void AddFund(Funds fund)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Funds>("funds");
            await collection.InsertOneAsync(fund);

        }

        public async static Task<List<Funds>> GetFunds()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Funds>("funds");
            return collection.Find(x => true).ToList();
        }

        public static void DeleteFund(Funds fund)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Funds>("funds");
            collection.DeleteOne(x => x.Id == fund.Id);
        }
        public static void EditFund()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var data = db.GetCollection<Funds>("funds");
            var UpdateDef = Builders<Funds>.Update.Set("Name", App.fund.Name);
            data.UpdateOne(basa => basa.Id == App.fund.Id, UpdateDef);
        }

        public static async Task<List<Funds>> SearchList(string word)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Funds>("funds");
            return collection.Find(x => x.Name == word).ToList();
        }
    }
}
