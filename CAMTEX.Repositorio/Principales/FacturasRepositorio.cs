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
    public class FacturasRepositorio : DDataAccess, IGeneralRepositorio<Factura>
    {
        public IDictionary<string, object> Actualizar(Factura entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Factura entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Factura entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Factura entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Factura]");
            return dt;
        }

        public DataTable ListarPaginado(Factura entidad)
        {
            throw new NotImplementedException();
        }
    }
}
