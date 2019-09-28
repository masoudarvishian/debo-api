namespace DEBO.Core.Entity.Contact
{
    public class Contact : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
