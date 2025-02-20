using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]
    public class Factura:EntidadBase
    {/*
        [DataMember] public string NroFactura { get; set; }
        [DataMember] public string Proveedor { get; set; }
        [DataMember] public DateTime? Fecha { get; set; }
        [DataMember] public string Concepto { get; set; }
        [DataMember] public int Valor { get; set; }
        [DataMember] public string Moneda { get; set; }
        */

        [DataMember] public string U_DIN_PROV { get; set; }
        [DataMember] public int U_DIN_FCSOL { get; set; }
        [DataMember] public string U_DIN_MON { get; set; }
        [DataMember] public string U_DIN_COND { get; set; }
        [DataMember] public DateTime? U_DIN_FFACT { get; set; }
        [DataMember] public string U_DIN_NFACT { get; set; }
        [DataMember] public string U_DIN_BL { get; set; }
        [DataMember] public string U_DIN_VIA { get; set; }
        [DataMember] public string U_DIN_AADU { get; set; }
        [DataMember] public string U_DIN_ACAR { get; set; }
        [DataMember] public string U_DIN_DEPO { get; set; }

    }
}

		