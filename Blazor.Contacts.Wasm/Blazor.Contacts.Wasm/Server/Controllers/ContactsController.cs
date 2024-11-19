using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Contacts.Wasm.Repositories;
using Blazor.Contacts.Wasm.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blazor.Contacts.Wasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository) {
            _contactRepository = contactRepository;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            if (contact == null) {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(contact.nombre))
                ModelState.AddModelError("Nombre", "Debe indicar un nombre de contacto");
            if (string.IsNullOrEmpty(contact.apellidos))
                ModelState.AddModelError("Apellidos", "Debe indicar los apellidos de contacto");
            if (string.IsNullOrEmpty(contact.direccion))
                ModelState.AddModelError("Dirección", "Debe indicar la dirección del contacto");
            if (string.IsNullOrEmpty(contact.municipio))
                ModelState.AddModelError("Municipio", "Debe indicar el municipio de contacto");
            if (string.IsNullOrEmpty(contact.ciudad))
                ModelState.AddModelError("Ciudad", "Debe indicar la ciudad del contacto");
            if (string.IsNullOrEmpty(contact.pais))
                ModelState.AddModelError("País", "Debe indicar el país del contacto");
            if (string.IsNullOrEmpty(contact.telefono1))
                ModelState.AddModelError("Teléfono 1", "Debe indicar un teléfono de contacto");
            if (string.IsNullOrEmpty(contact.telefono2))
                ModelState.AddModelError("Teléfono 2", "Debe indicar otro teléfono de contacto");
            if (string.IsNullOrEmpty(contact.email))
                ModelState.AddModelError("Email", "Debe indicar un email de contacto");


            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try
            {
                await _contactRepository.InsertContact(contact);
            }
            catch (Exception ex) {
                string sErr = ex.Message;
            }
           

            return NoContent();

        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(contact.nombre))
                ModelState.AddModelError("Nombre", "Debe indicar un nombre de contacto");
            if (string.IsNullOrEmpty(contact.apellidos))
                ModelState.AddModelError("Apellidos", "Debe indicar los apellidos de contacto");
            if (string.IsNullOrEmpty(contact.direccion))
                ModelState.AddModelError("Dirección", "Debe indicar la dirección del contacto");
            if (string.IsNullOrEmpty(contact.municipio))
                ModelState.AddModelError("Municipio", "Debe indicar el municipio de contacto");
            if (string.IsNullOrEmpty(contact.ciudad))
                ModelState.AddModelError("Ciudad", "Debe indicar la ciudad del contacto");
            if (string.IsNullOrEmpty(contact.pais))
                ModelState.AddModelError("País", "Debe indicar el país del contacto");
            if (string.IsNullOrEmpty(contact.telefono1))
                ModelState.AddModelError("Teléfono 1", "Debe indicar un teléfono de contacto");
            if (string.IsNullOrEmpty(contact.telefono2))
                ModelState.AddModelError("Teléfono 2", "Debe indicar otro teléfono de contacto");
            if (string.IsNullOrEmpty(contact.email))
                ModelState.AddModelError("Email", "Debe indicar un email de contacto");


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactRepository.UpdateContact(contact);

            return NoContent();
        }


        // GET: api/values
        [HttpGet]
        public async Task< IEnumerable<Contact>> Get()
        {
            return await _contactRepository.GetAll();
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _contactRepository.GetDatails(id);
            
        }

     

    
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _contactRepository.DeleteContact(id);
        }
    }
}

