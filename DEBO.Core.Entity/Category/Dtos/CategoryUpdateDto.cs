using System.ComponentModel.DataAnnotations;

namespace DEBO.Core.Entity.Category.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
