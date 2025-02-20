using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
   public class Incoterm:EntidadBase
    {
        [DataMember] public int IdIncoterm { get; set; }
        [DataMember] public string U_DIN_INCO { get; set; }
        [DataMember] public string Descripcion { get; set; }
    }
}
