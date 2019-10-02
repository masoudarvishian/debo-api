using System.ComponentModel.DataAnnotations;

namespace DEBO.Core.Entity.Contact.Dtos
{
    public class ContactInsertDto
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="وارد کردن {0} اجباری است")]
        [Display(Name ="شماره موبایل")]
        public string PhoneNumber { get; set; }
    }
}
