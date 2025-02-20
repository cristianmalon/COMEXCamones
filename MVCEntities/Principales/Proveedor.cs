using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Proveedor:EntidadBase
    {
        [DataMember] public string PrvCCod { get; set; }  //codigo primario
        [DataMember] public string PrvDDes { get; set; }  //Descripcion
        [DataMember] public string PrvDRuc { get; set; }  //RUC
        [DataMember] public string PrvDDir { get; set; }   //direccion
        [DataMember] public string PrvDTel { get; set; }   //Telefono
        [DataMember] public string PrvSEst { get; set; }  //ESTADO
        [DataMember] public string PrvCSap { get; set; }  //SAP
        [DataMember] public int IdProveedor { get; set; }  //Id Proveedor

    }
}
