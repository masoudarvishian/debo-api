namespace DEBO.Core.Entity.CategoryGroupCategory
{
    using Category;
    using CategoryGroup;

    public class CategoryGroupCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CategoryGroupId { get; set; }
        public CategoryGroup CategoryGroup { get; set; }
    }
}
