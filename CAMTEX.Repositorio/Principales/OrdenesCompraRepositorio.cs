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
    public class OrdenesCompraRepositorio : DDataAccess, IGeneralRepositorio<OrdenesCompra>
    {
        public IDictionary<string, object> Actualizar(OrdenesCompra entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(OrdenesCompra entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(OrdenesCompra entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(OrdenesCompra entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_OrdenesCompa]");
            return dt;
        }

        public DataTable ListarPaginado(OrdenesCompra entidad)
        {
            throw new NotImplementedException();
        }
    }
}
