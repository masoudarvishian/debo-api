using System.ComponentModel.DataAnnotations;
using DEBO.Core.Entity.BaseDtos;

namespace DEBO.Core.Entity.Category.Dtos
{
    public class CategoryUpdateDto : UpdateDto<int>
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
