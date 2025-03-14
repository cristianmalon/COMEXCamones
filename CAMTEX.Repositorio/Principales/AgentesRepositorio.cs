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
    public class AgentesRepositorio : DDataAccess, IGeneralRepositorio<Agentes>
    {
        public IDictionary<string, object> Actualizar(Agentes entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Agentes entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Agentes entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Agentes entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Agentes_Listar]");
            return dt;
        }

        public DataTable ListarPaginado(Agentes entidad)
        {
            throw new NotImplementedException();
        }
    }
}
