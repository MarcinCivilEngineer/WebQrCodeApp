using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace WebBetardQrCode.Models
{
    public class CreateCommentModel
    {
        [Required]
        [MaxLength(50)]
        public string Text { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Src { get; set; }
        [MaxLength(30)]
        public string Mail { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Company { get; set; }
    }
}
