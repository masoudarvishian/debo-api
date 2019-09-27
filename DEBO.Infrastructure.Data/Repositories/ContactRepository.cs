using DEBO.Core.DomainService;
using DEBO.Core.Entity.Contact;

namespace DEBO.Infrastructure.Data.Repositories
{
    public class ContactRepository : BaseRepository<Contact, int>, IContactRepository
    {
        public ContactRepository(ApplicationContext context) 
            : base(context) { }
    }
}
