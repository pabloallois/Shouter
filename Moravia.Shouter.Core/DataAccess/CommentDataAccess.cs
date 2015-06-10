﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using MongoDB.Driver;
using Moravia.Shouter.Core.Model;

namespace Moravia.Shouter.Core.DataAccess
{
    public class CommentDataAccess
    {
        #region GetComments
        public static IEnumerable<Comment> GetComments()
        {
            
            MongoDatabase db = DBConnection.Db();
            var comments = db.GetCollection<Comment>("comments");
            MongoDB.Driver.Builders.SortByBuilder sort = new MongoDB.Driver.Builders.SortByBuilder();
            sort.Descending("dateTime");
            return comments.FindAll().SetSortOrder(sort).ToList<Comment>();
        }
        #endregion

        #region InsertComment
        public static void InsertComment(Comment comment)
        {
            MongoDatabase db = DBConnection.Db();
            if (!db.CollectionExists("comments"))
                db.CreateCollection("comments");
            var comments = db.GetCollection("comments");

            var commentObject = new BsonDocument();
            commentObject["email"] = comment.email;
            commentObject["comment"] = comment.comment;
            commentObject["dateTime"] = DateTime.Now;
            comments.Insert(commentObject);
        }
        #endregion
    }
}