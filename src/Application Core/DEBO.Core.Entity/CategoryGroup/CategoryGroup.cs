namespace DEBO.Core.Entity.CategoryGroup
{
    using System.Collections.Generic;
    using CategoryGroupCategory;

    public class CategoryGroup : BaseEntity<int>
    {
        public string Title { get; set; }

        public ICollection<CategoryGroupCategory> CategoryGroupCategories { get; set; }
    }
}