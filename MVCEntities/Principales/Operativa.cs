using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Operativa:EntidadBase
    {
        [DataMember] public int IdFile { get; set; }
        [DataMember] public int IdOperativa { get; set; }
        [DataMember] public int IdOPeraciones { get; set; }
        [DataMember] public int IdLote { get; set; }
        [DataMember] public string NroOperacion { get; set; }
        [DataMember] public DateTime? FechaOperacion { get; set; }
        [DataMember] public int IdAgentes { get; set; }
        [DataMember] public int IdAgenteCarga { get; set; }
        [DataMember] public decimal Cantidad { get; set; }
    }
}

