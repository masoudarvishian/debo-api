namespace DEBO.Core.Entity.Category
{
    using System;
    using System.Collections.Generic;
    using CategoryGroupCategory;
    using Item;

    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }

        public List<CategoryGroupCategory> CategoryGroupLinks { get; set; } = new List<CategoryGroupCategory>();
        public List<Item> Items { get; set; } = new List<Item>();
    }
}