using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace asignacionKensysBackend.Models
{
	[Table("TipoPermiso")]
	public class TipoPermiso
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required, StringLength(100)]
		public string Descripcion { get; set; }

		//Navigations
		[JsonIgnore]
		public List<Permiso> Permisos { get; set; }
	}
}