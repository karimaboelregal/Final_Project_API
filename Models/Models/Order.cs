using Models.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public Admin Customer { get; set; }
        public Status Status { get; set; }
    }
}
