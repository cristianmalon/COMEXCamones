using CAMTEX.Entidades;
using CAMTEX.UtilData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CAMTEX.Repositorio
{
    public class OperacionesRepositorio : DDataAccess, IGeneralRepositorio<Operaciones>
    {
        public IDictionary<string, object> Actualizar(Operaciones entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Operaciones entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Operaciones entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();

            // Convertir JSON a XML
            XmlDocument xmlDocument = JsonConvert.DeserializeXmlNode("{\"root\":" + entidad.CadIdOc + "}", "root");

            // Convertir XML a cadena
            string xmlString = xmlDocument.OuterXml;

            // Enviar XML como parámetro al SP
            oConn.AddParameter("@opcion", 5);
            oConn.AddParameter("@FileID", entidad.NuevoFileID);
            oConn.AddParameter("@OC2", xmlString);

            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Files]");

            retorno.Add("resultado", true);
            retorno.Add("mensaje", "OK");
            return retorno;
        }

        public DataTable Listar(Operaciones entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarPaginado(Operaciones entidad)
        {
            throw new NotImplementedException();
        }
    }
}
