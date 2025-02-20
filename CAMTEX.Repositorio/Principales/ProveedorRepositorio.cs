using CAMTEX.Entidades;
using CAMTEX.UtilData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMTEX.Repositorio
{
    public class ProveedorRepositorio : DDataAccess, IGeneralRepositorio<Proveedor>
    {
        public IDictionary<string, object> Actualizar(Proveedor entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Proveedor entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Proveedor entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Proveedor entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Proveedor]");
            return dt;
        }

        public DataTable ListarPaginado(Proveedor entidad)
        {
            throw new NotImplementedException();
        }
    }
}
