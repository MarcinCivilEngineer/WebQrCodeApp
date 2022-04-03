using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class DrawingRevisionModel
    {
        public string Symbol { get; set; }
        public string Text { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataRegister { get; set; } = DateTime.UtcNow;
    }
}
