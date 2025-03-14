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
    public class OperacionesImpRepositorio : DDataAccess, IGeneralRepositorio<OperacionesImp>
    {
        public IDictionary<string, object> Actualizar(OperacionesImp entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 1);

            oConn.AddParameter("@FileID", entidad.FileID);
            oConn.AddParameter("@OrdenID", entidad.IdOperaciones);
            oConn.AddParameter("@NuevaFechaO", entidad.FechaEmbarque);
            oConn.AddParameter("@NuevoU_DIN_AADU", entidad.U_DIN_AADU);


            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_OperacionesImp]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public IDictionary<string, object> Eliminar(OperacionesImp entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(OperacionesImp entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(OperacionesImp entidad)
        {
            oConn.AddParameter("@FileID", entidad.FileID);
            oConn.AddParameter("@OrdenID", entidad.IdOperaciones);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_OperacionesImp_Lista]");
            return dt;
        }

        public DataTable ListarPaginado(OperacionesImp entidad)
        {
            throw new NotImplementedException();
        }
    }
}
