using System;
using Blazor.Contacts.Wasm.Shared;

namespace Blazor.Contacts.Wasm.Repositories
{
	// la firma de los métodos 

	public interface IContactRepository
	{
		Task<bool> InsertContact(Contact contacto);
		Task<bool> UpdateContact(Contact contacto);
		Task DeleteContact(int Id);
		Task<IEnumerable<Contact>> GetAll();
		Task<Contact> GetDatails(int Id);


    }
}

