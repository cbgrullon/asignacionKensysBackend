using System;
namespace asignacionKensysBackend
{
	public class Constants
	{
		public const string QUERY_TIPO_PERMISOS_LIST = "SELECT Id,Descripcion FROM TipoPermiso";
        public const string QUERY_PERMISOS_LIST = "SELECT Id,NombreEmpleado,ApellidosEmpleado,TipoPermiso,FechaPermiso FROM Permiso";
        public const string QUERY_PERMISO_BY_ID= "SELECT Id,NombreEmpleado,ApellidosEmpleado,TipoPermiso,FechaPermiso FROM Permiso WHERE Id = @id";
        public const string QUERY_TIPO_PERMISO_BY_ID = "SELECT Id,Descripcion FROM TipoPermiso WHERE Id = @id";
    }
}

