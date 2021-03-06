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
    public class MusItems
    {
        public MusItems(string name, string dateCreation, bool dateExact, string authors, string description, string fund, string status, string card)
        {
            Name = name;
            DateCreation = dateCreation;
            DateExact = dateExact;
            Authors = authors;
            Description = description;
            Status = status;
            Fund = fund;
            Card = card;
        }

        public MusItems(string name, string dateCreation, bool dateExact, string authors, string description, string fund, string card)
        {
            Name = name;
            DateCreation = dateCreation;
            DateExact = dateExact;
            Authors = authors;
            Description = description;
            Fund = fund;
            Card = card;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string DateCreation { get; set; }
        [BsonElement]
        public bool DateExact { get; set; }
        [BsonElement]
        public string Authors { get; set; }
        [BsonElement]
        public string Description { get; set; }
        [BsonElement]
        public string Status { get; set; }
        [BsonElement]
        public string Fund { get; set; }
        [BsonElement]
        public string Card { get; set; }


        public async static void AddMI(MusItems mi)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<MusItems>("musItems");
            await collection.InsertOneAsync(mi);

        }

        public async static Task<List<MusItems>> GetMI()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<MusItems>("musItems");
            return collection.Find(x => true).ToList();
        }
        public async static Task<List<MusItems>> GetMIInCard(string card)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<MusItems>("musItems");
            return collection.Find(x => x.Card == card).ToList();
        }

        public static void DeleteMI(MusItems mi)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<MusItems>("musItems");
            collection.DeleteOne(x => x.Id == mi.Id);
        }
        public static void EditMI()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var data = db.GetCollection<MusItems>("musItems");
            var UpdateDef = Builders<MusItems>.Update.Set("Name", App.mi.Name).Set("DateCreation", App.mi.DateCreation).Set("DateExact", App.mi.DateExact).Set("Authors", App.mi.Authors).Set("Description", App.mi.Description).Set("Status", App.mi.Status).Set("Fund", App.mi.Fund).Set("Card", App.mi.Card);
            data.UpdateOne(basa => basa.Id == App.mi.Id, UpdateDef);
        }

        public static async Task<List<MusItems>> SearchList(string word)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<MusItems>("musItems");
            return collection.Find(x => x.Name == word).ToList();
        }
    }
}
