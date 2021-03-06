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
    public class Cards
    {
        public Cards(string name, string fund)
        {
            Name = name;
            Fund = fund;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Fund { get; set; }

        public async static void AddCard(Cards card)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Cards>("card");
            await collection.InsertOneAsync(card);

        }

        public async static Task<List<Cards>> GetCards(string namefund)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Cards>("card");
            return collection.Find(x => x.Fund == namefund).ToList();
        }

        public async static Task<List<Cards>> GetAllCards()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Cards>("card");
            return collection.Find(x => true).ToList();
        }
        public static void DeleteCard(Cards card)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Cards>("card");
            collection.DeleteOne(x => x.Id == card.Id);
        }
        public static void EditCard()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var data = db.GetCollection<Cards>("card");
            var UpdateDef = Builders<Cards>.Update.Set("Name", App.card.Name).Set("Fund", App.card.Fund);
            data.UpdateOne(basa => basa.Id == App.card.Id, UpdateDef);
        }

        public static async Task<List<Cards>> SearchList(string word)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Cards>("card");
            return collection.Find(x => x.Name == word).ToList();
        }
    }
}
