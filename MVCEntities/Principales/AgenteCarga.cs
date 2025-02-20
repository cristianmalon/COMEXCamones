using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class AgenteCarga: EntidadBase
    {
        [DataMember] public int idAgenteCarga { get; set; }
        [DataMember] public string Nombre { get; set; }
        [DataMember] public string U_DIN_AADU { get; set; }
        [DataMember] public string U_DIN_ACAR { get; set; }
    }
}
