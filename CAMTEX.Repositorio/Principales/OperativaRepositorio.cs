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
    public class OperativaRepositorio : DDataAccess, IGeneralRepositorio<Operativa>
    {
        public IDictionary<string, object> Actualizar(Operativa entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 1);

            oConn.AddParameter("@NuevaFechaO", entidad.FechaOperacion);
            oConn.AddParameter("@Cantidad", entidad.Cantidad);

            oConn.AddParameter("@IdAgente", entidad.IdAgentes);
                        
            oConn.AddParameter("@IdAgenteCarga", entidad.IdAgenteCarga);
            oConn.AddParameter("@IdOperativa", entidad.IdOperativa);
            oConn.AddParameter("@IdLoteA", entidad.IdLote);
            oConn.AddParameter("@NroOperacionA", entidad.NroOperacion);
            

            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_OperacionesImp]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public IDictionary<string, object> Eliminar(Operativa entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 3);
            oConn.AddParameter("@IdOperativaD", entidad.IdOperativa);
            //oConn.AddParameter("@Usuario", entidad.USUARIO_REG);
            //oConn.AddParameter("@MaquinaPC", entidad.HOST_REG);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_OperacionesImp]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public IDictionary<string, object> Insertar(Operativa entidad)
        {
            //SE REQUIERE QUE EL IDFILE Y EL IDOPERACIONES ESTE RELACIONADOS PARA QUE SE PUEDA GUARDAR
            Dictionary<string, object> retorno = new Dictionary<string, object>();
            oConn.AddParameter("@opcion", 2);

            oConn.AddParameter("@FileID", entidad.IdFile);
            oConn.AddParameter("@IdOperaciones", entidad.IdOPeraciones);
            
            oConn.AddParameter("@IdLote", entidad.IdLote);
            oConn.AddParameter("@NroOperacion", entidad.NroOperacion);
            oConn.AddParameter("@NuevaFechaO", entidad.FechaOperacion);
            oConn.AddParameter("@IdAgente", entidad.IdAgentes);
            oConn.AddParameter("@IdAgenteCarga", entidad.IdAgenteCarga);
            oConn.AddParameter("@Cantidad", entidad.Cantidad);
            
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_OperacionesImp]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public DataTable Listar(Operativa entidad)
        {
            oConn.AddParameter("@FileID", entidad.IdFile);
            oConn.AddParameter("@OrdenID", entidad.IdOPeraciones);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_OperacionesImp_Lista]");
            return dt;
        }

        public DataTable ListarPaginado(Operativa entidad)
        {
            throw new NotImplementedException();
        }
    }
}
