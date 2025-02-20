using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class TipoImportacion:EntidadBase
    {
        [DataMember] public int IdTipoFile { get; set; }
        [DataMember] public string DetalleFile { get; set; }
        [DataMember] public string EstadoFile { get; set; }
    }
}
