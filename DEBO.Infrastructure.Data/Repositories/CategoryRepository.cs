using DEBO.Core.DomainService;
using DEBO.Core.Entity.Category;

namespace DEBO.Infrastructure.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>,
        ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}