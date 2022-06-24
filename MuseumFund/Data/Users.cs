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
    public class Users
    {
        public Users(string login, string pass)
        {
            Login = login;
            Pass = pass;
        }

        public Users(string surname, string name, string patronic, string nameOrganization, string login, string pass, bool isAdmin)
        {
            Surname = surname;
            Name = name;
            Patronic = patronic;
            NameOrganization = nameOrganization;
            Login = login;
            Pass = pass;
            IsAdmin = isAdmin;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Surname { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Patronic { get; set; }
        [BsonElement]
        public string NameOrganization { get; set; }
        [BsonElement]
        public string Login { get; set; }
        [BsonElement]
        public string Pass { get; set; }
        [BsonElement]
        public bool IsAdmin { get; set; }

        public async static void AddUser(Users user)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Users>("users");
            await collection.InsertOneAsync(user);
        }
        public static bool LogInUser(Users user)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var collection = db.GetCollection<Users>("users");
            var users = collection.Find(x => true).ToList();
            App.user = users.Where(x => x.Login == user.Login && x.Pass == user.Pass).FirstOrDefault();
            if (App.user == null)
                return false;
            return true;
        }
        public static void EditProfile()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("MuseumFund");
            var data = db.GetCollection<Users>("users");
            var UpdateDef = Builders<Users>.Update.Set("Name", App.user.Name).Set("Surname", App.user.Surname).Set("Patronic", App.user.Patronic).Set("Login", App.user.Login).Set("Pass", App.user.Pass);
            data.UpdateOne(basa => basa.Id == App.user.Id, UpdateDef);

        }
    }
}