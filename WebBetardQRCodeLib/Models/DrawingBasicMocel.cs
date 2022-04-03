using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class DrawingBasicMocel
    {
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DrawingBasicMocel()
        {

        }


        public DrawingBasicMocel( DrawingModel drawing)
        {

            Name = drawing.Name;
        }
    }
}
