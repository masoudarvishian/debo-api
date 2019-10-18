using System.ComponentModel.DataAnnotations;

namespace DEBO.Core.Entity.BaseDtos
{
    public class UpdateDto<TKey>
    {
        [Required]
        public TKey Id { get; set; }
    }
}
