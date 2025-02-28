using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Files:EntidadBase
    {
        [DataMember] public int FileId { get; set; }
        [DataMember] public string NombreF { get; set; }



        [DataMember] public string Detalle { get; set; }
        [DataMember] public string CodFile { get; set; }
        [DataMember] public string TipFile { get; set; }
        [DataMember] public DateTime? FechaCreacion  { get; set; }
        [DataMember] public string UsuarioCreacion { get; set; }
        [DataMember] public string Estacion { get; set; }
        [DataMember] public string Estado { get; set; }



        


        [DataMember] public DateTime? FechaOp { get; set; }
        [DataMember] public string NroOp { get; set; }
        
        [DataMember] public string CodProv { get; set; }
        [DataMember] public string Proveedor { get; set; }
        [DataMember] public string OrdC { get; set; }
        [DataMember] public string OrdenID { get; set; }
        [DataMember] public string Producto { get; set; }
        [DataMember] public string DesArt { get; set; }
        [DataMember] public int Solicitado { get; set; }
        [DataMember] public string DUA { get; set; }
        [DataMember] public int Deposito { get; set; }
        [DataMember] public string Situacion { get; set; }
        [DataMember] public DateTime? FechaIngreso { get; set; }
        [DataMember] public DateTime? FechaEmbarque { get; set; }
        [DataMember] public string EstadoRQ { get; set; }
        [DataMember] public string EstadoCalidad { get; set; }
        [DataMember] public int NumFactura { get; set; }
        [DataMember] public string LineaNaviera { get; set; }
        [DataMember] public int Contenedor { get; set; }
        [DataMember] public string AgenteAduana { get; set; }

        [DataMember] public string ViaTransporte { get; set; }









    }
}
