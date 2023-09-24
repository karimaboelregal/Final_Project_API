using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Customer : User
    {
        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
