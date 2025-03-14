using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class OperacionesImp
    {

        [DataMember] public int FileID { get; set; }
        [DataMember] public int IdOperaciones { get; set; }
        [DataMember] public int IdDatoGeneral { get; set; }
        [DataMember] public DateTime? FechaEmbarque { get; set; }
        [DataMember] public string CodigoLote { get; set; }
        [DataMember] public string Lote { get; set; }
        [DataMember] public string U_DIN_AADU { get; set; }
        [DataMember] public string U_DIN_ACAR { get; set; }
        [DataMember] public decimal Cantidad { get; set; }


    }
}
