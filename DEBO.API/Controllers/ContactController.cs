using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.Entity.Contact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DEBO.API.Controllers
{
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
        public ActionResult<IEnumerable<ContactDto>> Get()
        {
            var contacts = _contactService.GetAll();

            return Ok(contacts);
        }

        [HttpPost]
        public ActionResult Post(ContactDto contact)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var createdContact = _contactService.Insert(contact);

            return CreatedAtAction(nameof(Post), createdContact);
        }

        [HttpPut]
        public ActionResult Put(ContactDto contact)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}