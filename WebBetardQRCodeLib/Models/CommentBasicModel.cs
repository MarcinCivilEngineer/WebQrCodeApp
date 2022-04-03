using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class CommentBasicModel
    {
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public bool IsShow { get; set; } = true;
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public CommentBasicModel()
        {

        }
        public CommentBasicModel(CommentModel comment)
        {


            Text = comment.Text;
            IsShow = comment.IsShow;
            Data = comment.Data;
        }
    }
}
