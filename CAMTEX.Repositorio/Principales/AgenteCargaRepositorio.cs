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
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 2);
            oConn.AddParameter("@IdAgenteCargaD", entidad.idAgenteCarga);
            //oConn.AddParameter("@Usuario", entidad.USUARIO_REG);
            //oConn.AddParameter("@MaquinaPC", entidad.HOST_REG);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_AgenteCarga]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public IDictionary<string, object> Insertar(AgenteCarga entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();
            oConn.AddParameter("@opcion", 1);
            oConn.AddParameter("@Nombre", entidad.Nombre);
            oConn.AddParameter("@U_DIN_AADU", entidad.U_DIN_AADU);
            oConn.AddParameter("@U_DIN_ACAR", entidad.U_DIN_ACAR);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_AgenteCarga]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public DataTable Listar(AgenteCarga entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_AgenteCarga_Listar]");
            return dt;
        }

        public DataTable ListarPaginado(AgenteCarga entidad)
        {
            throw new NotImplementedException();
        }
    }
}
