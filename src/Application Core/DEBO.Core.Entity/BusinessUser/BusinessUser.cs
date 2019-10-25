namespace DEBO.Core.Entity.BusinessUser
{
    using User;
    using Business;

    public class BusinessUser
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
