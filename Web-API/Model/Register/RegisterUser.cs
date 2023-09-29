using System.ComponentModel.DataAnnotations;

namespace Web_API.Model.Register
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
