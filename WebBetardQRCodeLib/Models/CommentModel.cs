using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class CommentModel
    {
        public CommentUserModel CommentUser { get; set; } = new();
        public string Text { get; set; }
        public string Src { get; set; }
        public bool IsShow { get; set; } = true;
        public DateTime Data { get; set; } = DateTime.UtcNow;

    }
}
