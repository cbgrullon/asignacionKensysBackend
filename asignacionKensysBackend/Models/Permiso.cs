using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;
namespace asignacionKensysBackend.Models
{
	[Table("Permiso")]
	public class Permiso
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required, StringLength(100)]
		public string NombreEmpleado { get; set; }

        [Required, StringLength(100)]
        public string ApellidosEmpleado { get; set; }

        [Required]
        public int TipoPermisoId{ get; set; }

		[Required, DataType(DataType.Date)]
		public DateOnly FechaPermiso { get; set; }

		//Navigations
		public TipoPermiso TipoPermiso { get; set; }
    }
}

