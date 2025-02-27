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
            XmlDocument xmlDocumentDato = JsonConvert.DeserializeXmlNode("{\"root\":" + entidad.CadformDatoI + "}", "root");
            XmlDocument xmlDocumentL = JsonConvert.DeserializeXmlNode("{\"root\":" + entidad.CadLote + "}", "root");

            // Convertir XML a cadena
            string xmlString = xmlDocument.OuterXml;
            string xmlStringL = xmlDocumentL.OuterXml;
            string xmlStringDato = xmlDocumentDato.OuterXml;

            // Enviar XML como parámetro al SP
            oConn.AddParameter("@opcion", 5);
            oConn.AddParameter("@FileID", entidad.NuevoFileID);
            oConn.AddParameter("@OC2", xmlString);
            oConn.AddParameter("@CadLote", xmlStringL);
            oConn.AddParameter("@DatoI", xmlStringDato);

            // Agregar parámetro de salida para obtener el NuevoFileID
            oConn.agregarParametroSalida("@XmlResultado", SqlDbType.Xml, -1);
            oConn.agregarParametroSalida("@XmlResultadoDato", SqlDbType.Xml, -1);
            oConn.agregarParametroSalida("@XmlResultadoL", SqlDbType.Xml, -1);


                
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Files]");

            string nuevoFileID = Convert.ToString(oConn.obtenerParametroSalida("@XmlResultado"));
            string datoImp = Convert.ToString(oConn.obtenerParametroSalida("@XmlResultadoDato"));
            string datoL = Convert.ToString(oConn.obtenerParametroSalida("@XmlResultadoL"));


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
