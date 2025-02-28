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
    public class ContenedorRepositorio : DDataAccess, IGeneralRepositorio<Contenedores>
    {
        public IDictionary<string, object> Actualizar(Contenedores entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Contenedores entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            oConn.AddParameter("@opcion", 2);
            oConn.AddParameter("@IdContenedor", entidad.IdContenedor);
            //oConn.AddParameter("@Usuario", entidad.USUARIO_REG);
            //oConn.AddParameter("@MaquinaPC", entidad.HOST_REG);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Contenedor]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public IDictionary<string, object> Insertar(Contenedores entidad)
        {
            //SE REQUIERE QUE EL IDFILE Y EL IDOPERACIONES ESTE RELACIONADOS PARA QUE SE PUEDA GUARDAR
            Dictionary<string, object> retorno = new Dictionary<string, object>();
            oConn.AddParameter("@opcion", 1);
            oConn.AddParameter("@FileId", entidad.IdFile);
            oConn.AddParameter("@IdOperaciones", entidad.IdOPeraciones);
            oConn.AddParameter("@CodContenedor", entidad.Contenedor);            
            oConn.AddParameter("@usuario", entidad.USUARIO_REG);
            oConn.AddParameter("@Host", entidad.HOST_REG);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Contenedor]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public DataTable Listar(Contenedores entidad)
        {
            oConn.AddParameter("@opcion", 1);
            oConn.AddParameter("@file", entidad.IdFile);
            oConn.AddParameter("@idOp", entidad.IdOPeraciones);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_ContenedorListar]");
            return dt;
        }

        public DataTable ListarPaginado(Contenedores entidad)
        {
            throw new NotImplementedException();
        }
    }
}
