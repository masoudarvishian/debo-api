using System.ComponentModel.DataAnnotations;

namespace DEBO.Core.Entity.CategoryGroup.Dtos
{
    public class CategoryGroupInputDto
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MinLength(2)]
        [MaxLength(200)]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
