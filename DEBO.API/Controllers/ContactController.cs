using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.Entity.Constants;
using DEBO.Core.Entity.Contact;
using DEBO.Core.Entity.Contact.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEBO.API.Controllers
{
    [Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContactOutputDto>> Get()
        {
            var contacts = _contactService.GetAll();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<ContactOutputDto> GetById(int id)
        {
            var contact = _contactService.GetById(id);

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Post(ContactInsertDto contact)
        {
            var createdContact = await _contactService.InsertAsync(contact);

            return CreatedAtAction(nameof(Post), createdContact);
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> Put(ContactUpdateDto contact)
        {
            var updatedContact = await _contactService.UpdateAsync(contact);

            return Ok(updatedContact);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _contactService.DeleteAsync(id);

            return NoContent();
        }
    }
}