using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad
{
    public class EselectC
    {
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
    }

    public class Erespuesta
    {
        public int CODIGO { get; set; }
        public int ESTADO { get; set; }
    }

    public class EselectI
    {
        public int CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
    }

    public class EselectIv: EselectI
    {
        public decimal VALOR { get; set; }
    }

    public class Busqueda_Param
    {
        public string sidx { get; set; }
        public string sord { get; set; }
        public int page { get; set; }
        public int rows { get; set; }

    }

    public class Busqueda_Param_Usuario : Busqueda_Param
    {
        public int tipo { get; set; }
        public string valor { get; set; }
        public string estado { get; set; }
    }
    public class Busqueda_Param_Ws
    {
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string param3 { get; set; }
        public string param4 { get; set; }
        public string param5 { get; set; }
    }
}
