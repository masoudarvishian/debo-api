namespace DEBO.Core.Entity.CategoryGroup
{
    using System;
    using System.Collections.Generic;
    using CategoryGroupCategory;

    public class CategoryGroup : BaseEntity<int>
    {
        public string Title { get; set; }

        public List<CategoryGroupCategory> CategoryLinks { get; set; } = new List<CategoryGroupCategory>();
    }
}