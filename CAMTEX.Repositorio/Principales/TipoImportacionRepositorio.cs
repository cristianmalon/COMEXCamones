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
    public class TipoImportacionRepositorio : DDataAccess, IGeneralRepositorio<TipoImportacion>
    {
        public IDictionary<string, object> Actualizar(TipoImportacion entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(TipoImportacion entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(TipoImportacion entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(TipoImportacion entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_TipoImportacion]");
            return dt;
        }

        public DataTable ListarPaginado(TipoImportacion entidad)
        {
            throw new NotImplementedException();
        }
    }
}
