
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class DrawingModel
    {
        public string Name { get; set; }
        public List<DrawingRevisionModel> DrawingRevision { get; set; } = new();
        public List<CommentModel> Comments { get; set; } = new();
        public List<DrawingStatusModel> DrawingStatus { get; set; } = new();
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }
}
