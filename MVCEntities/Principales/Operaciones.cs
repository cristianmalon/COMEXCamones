using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Operaciones:EntidadBase
    {
        [DataMember] public int NroFile { get; set; }
        [DataMember] public string NroOperacion { get; set; }
        [DataMember] public DateTime Fecha { get; set; }
        [DataMember] public string Codigo { get; set; }
        [DataMember] public string NroLotes { get; set; }
        [DataMember] public string AgteAduana { get; set; }
        [DataMember] public string AgteCarga { get; set; }
        [DataMember] public int Qty { get; set; }



        [DataMember] public string NuevoFileID { get; set; }

        [DataMember] public string CadIdOc { get; set; }
        [DataMember] public string CadLote { get; set; }
        [DataMember] public string CadformDatoI { get; set; }



        


    }
}
