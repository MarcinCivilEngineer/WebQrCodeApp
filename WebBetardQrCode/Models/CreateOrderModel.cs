using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBetardQrCode.Models
{
    public class CreateOrderModel
    {
        [Required]
        [MaxLength(15)]
        public string NumberBET { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }
    }
}
