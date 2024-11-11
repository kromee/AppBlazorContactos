using System;
using System.Data;
using Blazor.Contacts.Wasm.Shared;
using Dapper;

namespace Blazor.Contacts.Wasm.Repositories
{
	public class ContactResitory: IContactRepository
	{
		private readonly IDbConnection _dbConnection;

		public ContactResitory(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
        }

        public  async Task DeleteContact(int Id)
        {
            var slqDelete = @"delete from  Contacts " +
                               " where id=@Id ";
            var result = await _dbConnection.ExecuteAsync(slqDelete, new { id = Id });
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var slqSelectall = @"Select id, nombre, apellidos, , Direccion, Municipio, Ciudad, Pais, Telefono1, Telefono2, Email " +
                                  " from Contacts ";
                                
            var contact = await _dbConnection.QueryAsync<Contact>(slqSelectall, new { });

            if (contact == null)
            {
                
                throw new Exception("Contacto no encontrado");
            }
            return contact;
        }

        public async Task<Contact> GetDatails(int IdContacto)
        {
            var slqSelectId = @"Select id, nombre, apellidos, , Direccion, Municipio, Ciudad, Pais, Telefono1, Telefono2, Email " +
                                " from Contacts " +
                                " where id=@Id";
            var contact = await _dbConnection.QueryFirstOrDefaultAsync<Contact>(slqSelectId, new { Id = IdContacto });

            if (contact == null)
            {
                // Manejar el caso en que el contacto no fue encontrado (ejemplo: lanzar una excepción, devolver un valor por defecto, etc.)
                throw new Exception("Contacto no encontrado");
            }
            return contact;


        }

        public async Task<bool> InsertContact(Contact contacto)
        {
            var sqlInsert = @"insert into Contactos (Nombre, Apellidos, Direccion, Municipio, Ciudad, Pais, Telefono1, Telefono2, Email)" +
                                 "Values (@Nombre, @Apellidos, @Direccion, @Municipio,@Ciudad, @Pais, @Telefono1, @Telefono2, @Email)";

            var result = await _dbConnection.ExecuteAsync(sqlInsert, new
            {
                contacto.nombre,
                contacto.apellidos,
                contacto.direccion,
                contacto.municipio,
                contacto.ciudad,
                contacto.pais,
                contacto.telefono1,
                contacto.telefono2,
                contacto.email

            });

            return result > 0;


        }

        public async Task<bool> UpdateContact(Contact contacto)
        {
            var sqlUpdate = @"Update Contactos Nombre=@Nombre, Apellidos=@Apellidos, Direccion=@Direccion, Municipio=@Municipio, Ciudad=@Ciudad, Pais=@Pais, Telefono1=@Telefono1, Telefono2=@Telefono2, Email=@Email)" +
                               "  where Id=@Id";

            var result = await _dbConnection.ExecuteAsync(sqlUpdate, new
            {
                contacto.nombre,
                contacto.apellidos,
                contacto.direccion,
                contacto.municipio,
                contacto.ciudad,
                contacto.pais,
                contacto.telefono1,
                contacto.telefono2,
                contacto.email,
                contacto.ID

            });

            return result > 0;
        }
    }
}

