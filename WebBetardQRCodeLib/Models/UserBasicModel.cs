using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class UserBasicModel
    {
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string ObjectIdentifier { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string LastAuthCode { get; set; }
        public UserBasicModel()
        {

        }
        public UserBasicModel(UserModel user)
        {
            Id = user.Id;
            ObjectIdentifier = user.ObjectIdentifier;
            Mail = user.Mail;
            Phone = user.Phone;
            Company = user.Company;
            LastAuthCode = user.LastAuthCode;
        }
    }
}
