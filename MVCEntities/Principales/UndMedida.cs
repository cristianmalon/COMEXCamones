using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class UndMedida:EntidadBase
    {
        [DataMember] public string UniCCod { get; set; }
        [DataMember] public string UniDDes { get; set; }
        [DataMember] public string UnisEst { get; set; }
        [DataMember] public string UndCcodSunat { get; set; }
    }
}
