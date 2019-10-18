using System.ComponentModel.DataAnnotations;

namespace DEBO.Core.Entity.Category.Dtos
{
    public class CategoryUpdateDto
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MinLength(2)]
        [MaxLength(200)]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
