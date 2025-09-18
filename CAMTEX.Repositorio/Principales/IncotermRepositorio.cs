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
    public class IncotermRepositorio : DDataAccess, IGeneralRepositorio<Incoterm>
    {
        public IDictionary<string, object> Actualizar(Incoterm entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 3);
            oConn.AddParameter("@U_DIN_INCO", entidad.U_DIN_INCO);
            oConn.AddParameter("@Descripcion", entidad.Descripcion);
            oConn.AddParameter("@Estado", entidad.IdEstado);
            oConn.AddParameter("@Usuario", entidad.USUARIO_REG);
            oConn.AddParameter("@MaquinaPC", entidad.HOST_REG);
            oConn.AddParameter("@IdIncoterm", entidad.IdIncoterm);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Incoterm]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public IDictionary<string, object> Eliminar(Incoterm entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 4);
            oConn.AddParameter("@Usuario", entidad.USUARIO_REG);
            oConn.AddParameter("@MaquinaPC", entidad.HOST_REG);
            oConn.AddParameter("@IdIncoterm", entidad.IdIncoterm);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Incoterm]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public IDictionary<string, object> Insertar(Incoterm entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 2);
            oConn.AddParameter("@U_DIN_INCO", entidad.U_DIN_INCO);
            oConn.AddParameter("@Descripcion", entidad.Descripcion);
            oConn.AddParameter("@Estado", entidad.IdEstado);
            oConn.AddParameter("@Usuario", entidad.USUARIO_REG);
            oConn.AddParameter("@MaquinaPC", entidad.HOST_REG);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Incoterm]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public DataTable Listar(Incoterm entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Incoterm]");
            return dt;
        }

        public DataTable ListarPaginado(Incoterm entidad)
        {
            throw new NotImplementedException();
        }
    }
}
