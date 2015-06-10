using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using Moravia.Shouter.Core.Tools;

namespace Moravia.Shouter.Core.Model
{
    public class Comment
    {
        public ObjectId _id { get; set; }
        public string email { get; set; }
        public DateTime dateTime { get; set; }
        public string comment { get; set; }

        public string PublishedElapsedTime
        {
            get
            {
                return DateTimeHelper.GetFriendlyElapsedTime(this.dateTime);
            }
        }

    }
}