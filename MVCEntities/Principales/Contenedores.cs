using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Contenedores:EntidadBase
    {
        [DataMember] public int IdFile { get; set; }
        [DataMember] public int IdOPeraciones { get; set; }
        [DataMember] public int IdContenedor { get; set; }
        [DataMember] public string Contenedor { get; set; }
    }
}
