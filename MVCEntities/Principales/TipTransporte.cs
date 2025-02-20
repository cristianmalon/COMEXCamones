using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace CAMTEX.Entidades
{
    [DataContract]
    public class TipTransporte:EntidadBase
    {
        [DataMember] public int idTransporte { get; set; }
        [DataMember] public string Nombre { get; set; }
        [DataMember] public string U_DIN_NAVE { get; set; }
        [DataMember] public DateTime? U_DIN_ETA { get; set; }
        [DataMember] public string Des_Trans { get; set; }
    }        
}
