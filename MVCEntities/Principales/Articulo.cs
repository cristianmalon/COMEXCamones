using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace CAMTEX.Entidades
{
    [DataContract]
    public class Articulo: EntidadBase
    {
        [DataMember] public string MaeCCod { get; set; }
        [DataMember] public string MaeDDes { get; set; }
        [DataMember] public string UniCCod { get; set; }
    }
}
