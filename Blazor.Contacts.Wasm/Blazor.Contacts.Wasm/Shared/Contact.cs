using System;
namespace Blazor.Contacts.Wasm.Shared
{
	public class Contact
	{
		

		public int ID { get; set; }
		public string? nombre { get; set; }
		public string? apellidos { get; set; }
		public string? direccion { get; set; }
		public string? municipio { get; set; }
		public string? ciudad { get; set; }
		public string? pais { get; set; }
		public string? telefono1 { get; set; }
		public string? telefono2 { get; set; }
		public string? email { get; set; }

		public string FullName {
			get {
				return apellidos + " " + nombre;
			}
		}



	}
}

