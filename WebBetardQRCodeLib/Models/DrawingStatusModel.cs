using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class DrawingStatusModel
    {
        public DrawingStatusTypeModel DrawingStatusType { get; set; } = new();
        public UserModel User { get; set; } = new();
        public DateTime Data { get; set; } = DateTime.UtcNow;

    }
}
