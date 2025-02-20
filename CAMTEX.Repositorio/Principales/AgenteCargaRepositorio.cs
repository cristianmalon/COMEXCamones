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
    public class AgenteCargaRepositorio : DDataAccess, IGeneralRepositorio<AgenteCarga>
    {
        public IDictionary<string, object> Actualizar(AgenteCarga entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(AgenteCarga entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(AgenteCarga entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(AgenteCarga entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_AgenteCarga]");
            return dt;
        }

        public DataTable ListarPaginado(AgenteCarga entidad)
        {
            throw new NotImplementedException();
        }
    }
}
