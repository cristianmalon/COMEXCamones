using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Producto:EntidadBase
    {
        [DataMember] public string Codigo { get; set; }
        [DataMember] public int OrcCItem { get; set; }
        [DataMember] public int OrdenID { get; set; }
        [DataMember] public string OrccnSap { get; set; }
        [DataMember] public string Descripcion { get; set; }
        [DataMember] public decimal PU { get; set; }
        [DataMember] public decimal Qty { get; set; }
        [DataMember] public decimal Valor { get; set; }
        [DataMember] public int OcId { get; set; }
    }
}
