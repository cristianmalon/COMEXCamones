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
    public class FilesRepositorio : DDataAccess, IGeneralRepositorio<Files>
    {
        public IDictionary<string, object> Actualizar(Files entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Files entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Files entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();
            oConn.AddParameter("@opcion", 2);
            oConn.AddParameter("@CodFile", entidad.CodFile);
            oConn.AddParameter("@Obs", entidad.Detalle);
            oConn.AddParameter("@Usuario", entidad.UsuarioCreacion);
            oConn.AddParameter("@Host", entidad.Estacion);

            // Agregar parámetro de salida para obtener el NuevoFileID
            oConn.agregarParametroSalida("@NuevoFileID", SqlDbType.Int,int.MaxValue );


            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Files]");


            int nuevoFileID = Convert.ToInt32(oConn.obtenerParametroSalida("@NuevoFileID"));


            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            retorno.Add("NuevoFileID", nuevoFileID); // Devolver el nuevo ID generado
            return retorno;

        }
        public IDictionary<string, object> InsertarE(Files entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();
            oConn.AddParameter("@opcion", 4);
            oConn.AddParameter("@CodFile", entidad.CodFile);
            oConn.AddParameter("@Obs", entidad.Detalle);
            oConn.AddParameter("@Usuario", entidad.UsuarioCreacion);
            oConn.AddParameter("@Host", entidad.Estacion);

            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Files]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;

        }


        public DataTable ListarI(Files entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Files_Lista]");
            return dt;
        }

        public DataTable ListarE(Files entidad)
        {
            oConn.AddParameter("@opcion", 3);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Files]");
            return dt;
        }
        public DataTable ListarPaginado(Files entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Files entidad)
        {
            throw new NotImplementedException();
        }
    }
}
