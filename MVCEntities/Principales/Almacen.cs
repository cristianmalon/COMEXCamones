using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Almacen:EntidadBase
    {
        [DataMember] public string AlmCCod { get; set; }
        [DataMember] public string TarCCod { get; set; }
        [DataMember] public string CCOCCod { get; set; }
        [DataMember] public string TipoAlmSunat { get; set; }
    }
}
