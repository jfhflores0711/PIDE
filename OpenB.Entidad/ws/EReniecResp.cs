using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad.ws
{
    public class EReniecResp
    {
        public ConsultarResponse consultarResponse { get; set; }
    }

    public class ConsultarResponse
    {
        public Return @return {get;set;}
    }

    public class Return {
        public string coResultado { get; set; }
        public DatosPersona datospersona { get; set; }
        public string deResultado { get; set; }
    }

    public class DatosPersona
    {
        public string apPrimer { get; set; }
        public string apSegundo { get; set; }
        public string direccion { get; set; }
        public string estadoCivil { get; set; }
        public string foto { get; set; }
        public string prenombres { get; set; }
        public string restriccion { get; set; }
        public string ubigeo { get; set; }

    }

}
