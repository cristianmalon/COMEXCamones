using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class SituacionEstado
    {
        [DataMember] public string Nombre { get; set; }
        [DataMember] public string Estado { get; set; }
    }
}
