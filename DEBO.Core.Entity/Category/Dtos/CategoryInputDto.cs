using System.ComponentModel.DataAnnotations;

namespace DEBO.Core.Entity.Category.Dtos
{
    public class CategoryInputDto
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
