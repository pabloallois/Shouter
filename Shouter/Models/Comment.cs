using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace Shouter.Models
{
    public class Comment
    {
        public ObjectId _id { get; set; }
        public string email { get; set; }
        public DateTime dateTime { get; set; }
        public string comment { get; set; }
    }
}