namespace DEBO.Core.Entity.Category
{
    using System.Collections.Generic;
    using CategoryGroupCategory;
    using Item;

    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }

        public ICollection<CategoryGroupCategory> CategoryGroupLinks { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}