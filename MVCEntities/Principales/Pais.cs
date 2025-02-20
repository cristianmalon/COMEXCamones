using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Pais
    {
        [DataMember] public int IdPais { get; set; }
        [DataMember] public string Nombre { get; set; }
    }
}
    