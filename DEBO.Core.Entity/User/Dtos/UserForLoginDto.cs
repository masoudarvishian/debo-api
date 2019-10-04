using System.ComponentModel.DataAnnotations;

namespace DEBO.Core.Entity.User.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
