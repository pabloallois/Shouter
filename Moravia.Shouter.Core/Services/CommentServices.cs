using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using MongoDB.Driver;
using Moravia.Shouter.Core.Model;
using Moravia.Shouter.Core.DataAccess;

namespace Moravia.Shouter.Core.Services
{
    public class CommentServices
    {
        #region GetComments
        public static IEnumerable<Comment> GetComments()
        {
            return CommentDataAccess.GetComments();
        }
        #endregion

        #region InsertComment
        public static void InsertComment(Comment comment)
        {
            CommentDataAccess.InsertComment(comment);
        }
        #endregion

    }
}