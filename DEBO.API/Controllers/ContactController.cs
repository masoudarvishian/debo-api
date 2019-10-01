using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.CustomExceptions;
using DEBO.Core.Entity.Contact;
using DEBO.Core.Entity.Contact.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public ActionResult<IEnumerable<ContactOutputDto>> Get()
        {
            try
            {
                var contacts = _contactService.GetAll();

                return Ok(contacts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ContactOutputDto> GetById(int id)
        {
            try
            {
                var contact = _contactService.GetById(id);

                return Ok(contact);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Post(ContactInsertDto contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var createdContact = await _contactService.InsertAsync(contact);

                return CreatedAtAction(nameof(Post), createdContact);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> Put(ContactUpdateDto contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var updatedContact = await _contactService.UpdateAsync(contact);

                return Ok(updatedContact);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _contactService.DeleteAsync(id);

                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}