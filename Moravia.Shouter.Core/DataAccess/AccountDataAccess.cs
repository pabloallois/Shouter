using MongoDB.Bson;
using MongoDB.Driver;
using Moravia.Shouter.Core.Model;


namespace Moravia.Shouter.Core.DataAccess
{
    public class AccountDataAccess
    {
        #region GetUserByEmail
        public static User GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var db = DBConnection.Db();
            var users = db.GetCollection<User>("users");
            var query = new QueryDocument("email", email);

            return users.FindOne(query);

        }
        #endregion

        #region InsertUser
        public static void InsertUser(string email, string password)
        {
            // Create server settings to pass connection string, timeout, etc.
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            MongoServer server = new MongoServer(settings);
            // Get our database instance to reach collections and data
            // Database already created
            var database = server.GetDatabase("shouter");

            if (!database.CollectionExists("users"))
                database.CreateCollection("users");
            var user = new BsonDocument();
            user["email"] = email;
            user["password"] = password;
            database.GetCollection("users").Insert(user);
        }
        #endregion
    }
}
