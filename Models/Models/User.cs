using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        public string FullName { get; set; }
        public bool isActive { get; set; }
    }
}
