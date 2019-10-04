using System.ComponentModel.DataAnnotations;

namespace DEBO.Core.Entity.User.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "نام کاربری باید بین 3 تا 30 کاراکتر باشد")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "کلمه عبور باید بین 3 تا 30 کاراکتر باشد")]
        public string Password { get; set; }
    }
}
