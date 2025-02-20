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
    public class CondPagoRepositorio : DDataAccess, IGeneralRepositorio<CondPago>
    {
        public IDictionary<string, object> Actualizar(CondPago entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(CondPago entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(CondPago entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(CondPago entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Condpago]");
            return dt;
        }

        public DataTable ListarPaginado(CondPago entidad)
        {
            throw new NotImplementedException();
        }
    }
}
