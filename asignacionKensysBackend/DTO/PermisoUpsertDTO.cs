using System;
using System.ComponentModel.DataAnnotations;

namespace asignacionKensysBackend.DTO
{
	public class PermisoUpsertDTO
	{
		public int? Id { get; set; }
		[Required, StringLength(100)]
		public string NombreEmpleado { get; set; }

        [Required, StringLength(100)]
        public string ApellidosEmpleado { get; set; }

        [Required]
        public int? TipoPermisoId { get; set; }

        [Required, DataType(DataType.Date)]
        public DateOnly FechaPermiso { get; set; }
    }
}

