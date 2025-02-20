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
    public class UndMedidaRepositorio : DDataAccess, IGeneralRepositorio<UndMedida>
    {
        public IDictionary<string, object> Actualizar(UndMedida entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(UndMedida entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(UndMedida entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(UndMedida entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_UndMedida]");
            return dt;
        }

        public DataTable ListarPaginado(UndMedida entidad)
        {
            throw new NotImplementedException();
        }
    }
}
