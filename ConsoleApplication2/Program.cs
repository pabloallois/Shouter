    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using MongoDB.Driver;
using MongoDB.Bson;


namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterNewUser();
        }

        private static void RegisterNewUser()
        {
            string email="";
            string password;
            Console.WriteLine("New User");
            while(IsValid(email)!=true)
            {
                Console.WriteLine("Enter e-mail address:");
                email = Console.ReadLine();
            }
            Console.WriteLine("Enter a password:");
            password = Console.ReadLine();
            AddUser(email,password);
        }

        private static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void AddUser(string email, string password)
        {
            // Create server settings to pass connection string, timeout, etc.
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017 );
            // Create server object to communicate with our server
            MongoServer server = new MongoServer(settings);
            // Get our database instance to reach collections and data
            // Database already created
            var database = server.GetDatabase("shouter");

            if(!database.CollectionExists("users"))
                database.CreateCollection("users");
            var user = new BsonDocument();
            user["email"] = email;
            user["password"] = password;
            database.GetCollection("users").Insert(user);
        }
    }
}
