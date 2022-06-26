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
    public class Request
    {
        public Request(string user, string namemi, string nameorg, string addressOrganization, string phone, string fIO, string addressExhibition, string nameExhibition, string dateBegin, string dateEnd, string logus)
        {
            this.user = user;
            NameMi = namemi;
            NameOrganization = nameorg;
            AddressOrganization = addressOrganization;
            Phone = phone;
            FIO = fIO;
            AddressExhibition = addressExhibition;
            NameExhibition = nameExhibition;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            LoginUser = logus;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId id { get; set; }
        [BsonElement]
        public string user { get; set; }
        [BsonElement]
        public string NameMi { get; set; }
        [BsonElement]
        public string NameOrganization { get; set; }
        [BsonElement]
        public string AddressOrganization { get; set; }
        [BsonElement]
        public string Phone { get; set; }
        [BsonElement]
        public string FIO { get; set; }
        [BsonElement]
        public string AddressExhibition { get; set; }
        [BsonElement]
        public string NameExhibition { get; set; }
        [BsonElement]
        public string DateBegin { get; set; }
        [BsonElement]
        public string DateEnd { get; set; }
        [BsonElement]
        public string LoginUser { get; set; }

        public async static void AddReq(Request request)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Request>("request");
            await collection.InsertOneAsync(request);

        }
        public async static Task<List<Request>> GetReqs()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Request>("request");
            return collection.Find(x => x.LoginUser == App.user.Login).ToList();
        }
        public async static Task<List<Request>> GetAllReqs()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Request>("request");
            return collection.Find(x => true).ToList();
        }
        public static void DeleteReq(Request request)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Request>("request");
            collection.DeleteOne(x => x.id == request.id);
        }
    }
}
