using System;
using System.Net.Http.Json;
using Blazor.Contacts.Wasm.Shared;

namespace Blazor.Contacts.Wasm.Client.Services
{
	public class ContactService: IContactService
	{
        private readonly HttpClient _httpClient;

		public ContactService(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public async Task DeleteContact(int id)
        {
            await _httpClient.DeleteAsync($"api/contacts/{id}");
        }


        public async Task<IEnumerable<Contact>> GetAll()
        {
          
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>("api/contacts") ?? Enumerable.Empty<Contact>();


        }

        public async Task<Contact> GetDetails(int id)
        {
            
            return await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/{id}") ?? new Contact();
        }

        public async Task SaveContact(Contact contact)
        {
            if (contact.ID == 0)
                await _httpClient.PostAsJsonAsync<Contact>($"api/contacts", contact);
            else
                await _httpClient.PutAsJsonAsync<Contact>($"api/contacts/{contact.ID}", contact);

        }

       
    }
}

