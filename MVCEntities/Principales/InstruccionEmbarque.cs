using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class InstruccionEmbarque
    {
        [DataMember] public int RowNumber { get; set; }
        [DataMember] public string Control_Comex { get; set; }
        [DataMember] public int IE_Anio { get; set; }
        [DataMember] public int IE_Nro { get; set; }
        [DataMember] public string Cliente { get; set; }
        [DataMember] public string TipoPrd { get; set; }
        [DataMember] public Decimal? CantPrendas { get; set; }
        [DataMember] public List<Producto> ListaProducto { get; set; }

        [DataMember] public List<Situacion> ListaSituacion { get; set; }
        [DataMember] public List<ViaTransporte> ListaViatransporte { get; set; }
        [DataMember] public List<LineaNaviera> ListaLineaNaviera { get; set; }
        [DataMember] public List<AgenteCarga> ListaAgenteCarga { get; set; }
        [DataMember] public List<Agentes> ListaAgentes { get; set; }
        [DataMember] public List<Deposito> ListaDeposito { get; set; }
        [DataMember] public List<Arancel> ListaArancel { get; set; }
        [DataMember] public List<PuertoEmbarque> ListaPuertoEmbarque { get; set; }
        [DataMember] public List<Almacen> ListaAlmacen { get; set; }
        [DataMember] public List<Incoterm> ListaIncoterm { get; set; }
        [DataMember] public List<OperacionAlmacen> ListaOpeAlmacen { get; set; }

        [DataMember] public int IdDatoGeneral { get; set; }
        [DataMember] public string NumeroOperacion { get; set; }
        [DataMember] public int? IdVia { get; set; }
        [DataMember] public string BL { get; set; }
        [DataMember] public int? IdDeposito { get; set; }
        [DataMember] public string SerieFactura { get; set; }
        [DataMember] public string NumFactura { get; set; }
        [DataMember] public DateTime? FechaFactura { get; set; }
        [DataMember] public DateTime? FechaIngreso { get; set; }
        [DataMember] public DateTime? FechaEmbarque { get; set; }
        [DataMember] public int? Garantia { get; set; }
        [DataMember] public int? IdSituacion { get; set; }
        [DataMember] public int? IdLineaNaviera { get; set; }
        [DataMember] public int? IdAgente { get; set; }
        [DataMember] public int? IdAgenteCarga { get; set; }
        [DataMember] public int? IdIncoterm { get; set; }

        [DataMember] public DateTime? EtaCallao { get; set; }
        [DataMember] public DateTime? VctSobreEst { get; set; }
        [DataMember] public int? IdArancel { get; set; }
        [DataMember] public int? IdPuerEm { get; set; }
        [DataMember] public int? IdAlmacen { get; set; }
        [DataMember] public DateTime? FechaDeposito { get; set; }
        [DataMember] public string NroDua { get; set; }
    }
}