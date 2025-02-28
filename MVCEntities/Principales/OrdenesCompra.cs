using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class OrdenesCompra
    {
        [DataMember] public string NumeroOrden { get; set; }
        [DataMember] public string Facturacion { get; set; }
        [DataMember] public int Item { get; set; }
        [DataMember] public string PrvCCod { get; set; }
        [DataMember] public string PrvDDes { get; set; }
        [DataMember] public string TarDNem { get; set; }
        [DataMember] public string CNPDDes { get; set; }
        [DataMember] public string OrcDMon { get; set; }       
        [DataMember] public DateTime? FechaCreacion { get; set; }

        [DataMember] public string MaeCCod { get; set; }

        [DataMember] public string MaeDDes { get; set; }
        [DataMember] public int IdSituacion { get; set; }

        [DataMember] public int id { get; set; }
        [DataMember] public int FileID { get; set; }
        [DataMember] public int ItemOrdenCompra { get; set; }
        [DataMember] public int ItemNroEntregaOC { get; set; }
        [DataMember] public List<Producto> ListaProducto { get; set; }

    }
    public class Situacion
    {
        [DataMember] public string idsituacion { get; set; }
        [DataMember] public string situacion { get; set; }
    }
    public class ViaTransporte
    {
        [DataMember] public string idsituacion { get; set; }
        [DataMember] public string situacion { get; set; }
    }
    public class LineaNaviera
    {
        [DataMember] public string idsituacion { get; set; }
        [DataMember] public string situacion { get; set; }
    }
}
