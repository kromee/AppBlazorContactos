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
            try {
                var slqDelete = @"delete from  Contact " +
                               " where id=@Id ";
            var result = await _dbConnection.ExecuteAsync(slqDelete, new { id = Id });
            } catch (Exception ex) {
                string sER = ex.Message;
            }
          
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var slqSelectall = @"Select id, nombre, apellidos,Direccion, Municipio, Ciudad, Pais, Telefono1, Telefono2, Email " +
                                  " from Contact ";

            try {
                var contact = await _dbConnection.QueryAsync<Contact>(slqSelectall, new { });

                if (contact == null)
                {
                
                    throw new Exception("Contacto no encontrado");
                }
                return contact;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }

              
            
           
            
        }

        public async Task<Contact> GetDatails(int IdContacto)
        {
            var slqSelectId = @"Select id, nombre, apellidos, Direccion, Municipio, Ciudad, Pais, Telefono1, Telefono2, Email " +
                                " from Contact " +
                                " where id=@Id";

            try
            {
                var contact = await _dbConnection.QueryFirstOrDefaultAsync<Contact>(slqSelectId, new { Id = IdContacto });

                if (contact == null)
                {
                    // Manejar el caso en que el contacto no fue encontrado (ejemplo: lanzar una excepción, devolver un valor por defecto, etc.)
                    throw new Exception("Contacto no encontrado");
                }
                return contact;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }


        }

        public async Task<bool> InsertContact(Contact contacto)
        {
            var sqlInsert = @"insert into Contact (Nombre, Apellidos, Direccion, Municipio, Ciudad, Pais, Telefono1, Telefono2, Email)" +
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
            var sqlUpdate = @"Update Contact set Nombre=@Nombre, Apellidos=@Apellidos, Direccion=@Direccion, Municipio=@Municipio, Ciudad=@Ciudad, Pais=@Pais, Telefono1=@Telefono1, Telefono2=@Telefono2, Email=@Email" +
                               "  where Id=@Id";

            try {
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
            } catch (Exception ex)
            {
                   throw new Exception(ex.Message);
            }
          
        }
    }
}

