﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System;

namespace CAMTEX.Entidades
{
    [DataContract]  
    public class Lotes:EntidadBase  
    {
        [DataMember] public int IdFile { get; set; }
        [DataMember] public int IdOPeraciones { get; set; }
        [DataMember] public string Codigo { get; set; }
        [DataMember] public string NroLotes { get; set; }
        [DataMember] public DateTime? Evaluacion { get; set; }
        [DataMember] public string EstadoLote { get; set; }
        [DataMember] public string Resultado { get; set; }
       // [DataMember] public string Deposito { get; set; }
        [DataMember] public int Destino { get; set; }
        [DataMember] public int IdLote { get; set; }
    }
}
