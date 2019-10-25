namespace DEBO.Core.Entity.Business
{
    using System.Collections.Generic;
    using BusinessUser;

    public class Business : BaseEntity<int>
    {
        public string Title { get; set; }

        public ICollection<BusinessUser> BusinessUsers { get; set; }
    }
}
