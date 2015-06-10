using System;
using System.Configuration;
using MongoDB.Driver;

namespace Moravia.Shouter.Core.DataAccess
{
    public class DBConnection
    {
        public static MongoDatabase Db()
        {

            var mongoDbServer = ConfigurationManager.AppSettings["MongoDbServer"];
            var mongoDbPort = Convert.ToInt32(ConfigurationManager.AppSettings["MongoDbPort"]);
            var mongoDbName = ConfigurationManager.AppSettings["MongoDbName"];

            // Create server settings to pass connection string, timeout, etc.
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress(mongoDbServer, mongoDbPort);
            // Create server object to communicate with our server
            MongoServer server = new MongoServer(settings);
            // Get our database instance to reach collections and data
            var database = server.GetDatabase(mongoDbName);
            
            return database;
        }
    }
}