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
    }
}