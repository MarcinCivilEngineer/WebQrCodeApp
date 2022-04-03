
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class UserLogModel
    {
        public string Text { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        
    }
}
