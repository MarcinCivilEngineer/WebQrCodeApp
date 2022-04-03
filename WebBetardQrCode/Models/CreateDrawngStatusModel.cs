using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebBetardQrCode.Models
{
    public class CreateDrawngStatusModel
    {
        [Required]
        [MaxLength(50)]
        public string DrawingStatusId { get; set; }
        [MaxLength(150)]
        public string UserId { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public string Pass { get; set; }
    }
}

