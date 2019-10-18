namespace DEBO.Core.Entity.User
{
    public class User : BaseEntity<int>
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
    }
}
