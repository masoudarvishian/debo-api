﻿namespace DEBO.Core.Entity.Category
{
    using System.Collections.Generic;
    using CategoryGroupCategory;

    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }

        public ICollection<CategoryGroupCategory> CategoryGroupCategories { get; set; }
    }
}