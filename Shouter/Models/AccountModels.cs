using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Shouter.Models
{
    public class LogOnModel
    {
        public static bool CanLogin(string email, string password)
        {
            if (email != "" && password != "")
            {
                MongoDatabase db = DBConnection.Db();
                var users = db.GetCollection("users");
                var query = new QueryDocument("email", email);
                var currentUser = users.FindOne(query);
                if (currentUser["email"] == email && currentUser["password"] == password)
                    return true;
            }
            return false;
        }

    }
}
