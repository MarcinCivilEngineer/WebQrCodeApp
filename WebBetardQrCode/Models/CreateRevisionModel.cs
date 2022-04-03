using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebBetardQrCode.Models
{
    public class CreateRevisionModel
    {
        [Required]
        [MaxLength(50)]
        public string Symbol { get; set; }
        [MaxLength(150)]
        public string Text { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }
}
