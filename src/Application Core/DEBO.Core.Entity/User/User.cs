namespace DEBO.Core.Entity.User
{
    using BusinessUser;
    using System.Collections.Generic;

    public class User : BaseEntity<int>
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }

        public ICollection<BusinessUser> BusinessUsers { get; set; }
    }
}
