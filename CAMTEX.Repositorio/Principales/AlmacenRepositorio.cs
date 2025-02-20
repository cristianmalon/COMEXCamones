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
    public class AlmacenRepositorio : DDataAccess, IGeneralRepositorio<Almacen>
    {
        public IDictionary<string, object> Actualizar(Almacen entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Almacen entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Almacen entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Almacen entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Almacenes]");
            return dt;
        }

        public DataTable ListarPaginado(Almacen entidad)
        {
            throw new NotImplementedException();
        }
    }
}
