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
    public class LotesRepositorio : DDataAccess, IGeneralRepositorio<Lotes>
    {
        public IDictionary<string, object> Actualizar(Lotes entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Lotes entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 2);
            oConn.AddParameter("@IdLote", entidad.IdLote);
            //oConn.AddParameter("@Usuario", entidad.USUARIO_REG);
            //oConn.AddParameter("@MaquinaPC", entidad.HOST_REG);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Lotes]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public IDictionary<string, object> Insertar(Lotes entidad)
        {
            //SE REQUIERE QUE EL IDFILE Y EL IDOPERACIONES ESTE RELACIONADOS PARA QUE SE PUEDA GUARDAR
            Dictionary<string, object> retorno = new Dictionary<string, object>();
            oConn.AddParameter("@opcion", 1);
            oConn.AddParameter("@FileId", entidad.IdFile);
            oConn.AddParameter("@IdOperaciones", entidad.IdOPeraciones);
            oConn.AddParameter("@CodLote", entidad.Codigo);
            oConn.AddParameter("@Lote", entidad.NroLotes);
            oConn.AddParameter("@Evaluacion", entidad.Evaluacion);
            oConn.AddParameter("@EstadoL", entidad.EstadoLote);
            oConn.AddParameter("@Resultado", entidad.Resultado);
            oConn.AddParameter("@IdDestP", entidad.Destino);
            oConn.AddParameter("@DepositoCad", entidad.DepositoCad);
            oConn.AddParameter("@usuario", entidad.USUARIO_REG);
            oConn.AddParameter("@Host", entidad.HOST_REG);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Lotes]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public DataTable Listar(Lotes entidad)
        {
            oConn.AddParameter("@opcion", 1);
            oConn.AddParameter("@file", entidad.IdFile);
            oConn.AddParameter("@idOp", entidad.IdOPeraciones);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_ListarLotes]");
            return dt;
        }

        public DataTable ListarPaginado(Lotes entidad)
        {
            throw new NotImplementedException();
        }
    }
}
