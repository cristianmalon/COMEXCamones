using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class OperacionAlmacen
    {
        [DataMember] public string FechaGuia { get; set; }
        [DataMember] public string NroGuia { get; set; }
        [DataMember] public string ArticuloGuia { get; set; }
        [DataMember] public decimal Cantidad { get; set; }
        [DataMember] public int id { get; set; }
    }
}
