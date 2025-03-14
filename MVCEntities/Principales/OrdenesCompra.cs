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
        [DataMember] public string OrdenCompraSAP { get; set; }
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
        

        [DataMember] public int id { get; set; }
        [DataMember] public int FileID { get; set; }
        [DataMember] public int ItemOrdenCompra { get; set; }
        [DataMember] public int ItemNroEntregaOC { get; set; }
        [DataMember] public List<Producto> ListaProducto { get; set; }
        [DataMember] public List<Situacion> ListaSituacion { get; set; }
        [DataMember] public List<ViaTransporte> ListaViatransporte { get; set; }
        [DataMember] public List<LineaNaviera> ListaLineaNaviera { get; set; }
        
        
        [DataMember] public List<AgenteCarga> ListaAgenteCarga { get; set; }
        [DataMember] public List<Agentes> ListaAgentes { get; set; }

        
        [DataMember] public int IdOperaciones { get; set; }
        [DataMember] public int IdDatoGeneral { get; set; }
        [DataMember] public string NumeroOperacion { get; set; }
        [DataMember] public int? IdVia { get; set; }
        [DataMember] public int? BL { get; set; }
        [DataMember] public int? IdDeposito { get; set; }
        [DataMember] public string SerieFactura { get; set; }
        [DataMember] public string NumFactura { get; set; }
        [DataMember] public DateTime? FechaIngreso { get; set; }
        [DataMember] public DateTime? FechaEmbarque { get; set; }
        [DataMember] public int Garantia { get; set; }
        [DataMember] public int? IdSituacion { get; set; }
        [DataMember] public int? IdLineaNaviera { get; set; }

        [DataMember] public string Usuario { get; set; }
        [DataMember] public string Host { get; set; }

    }
    public class Situacion
    {
        [DataMember] public int Idsituacion { get; set; }
        [DataMember] public string DesSituacion { get; set; }
    }
    public class ViaTransporte
    {
        [DataMember] public int IdVia { get; set; }
        [DataMember] public string DesViaTransporte { get; set; }
    }
    public class LineaNaviera
    {
        [DataMember] public int IdLineaNaviera { get; set; }
        [DataMember] public string DesLineaNaviera { get; set; }
    }
}
