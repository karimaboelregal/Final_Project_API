using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Admin : User
    {
        [Required]
        public string JobTitle { get; set; }
    }
}
