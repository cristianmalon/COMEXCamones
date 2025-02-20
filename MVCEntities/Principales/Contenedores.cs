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
        [DataMember] public int Id { get; set; }
        [DataMember] public string Nombre { get; set; }
    }
}
