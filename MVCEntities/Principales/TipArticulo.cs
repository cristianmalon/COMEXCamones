using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class TipArticulo:EntidadBase
    {
        [DataMember] public string TarCCod { get; set; }
        [DataMember] public string TarDDes { get; set; }
        [DataMember] public string TarSEst { get; set; }
        [DataMember] public string TarDNem { get; set; }
    }
}
