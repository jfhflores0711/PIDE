using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad.ws
{
    public class ESunarpOfi
    {
        public string numeroPartida { get; set; }
        public string oficina { get; set; }
        public string registro { get; set; }

    }

    public class ESunarpPlaca
    {
        public string oficina { get; set; }
        public string placa { get; set; }

    }

    public class ESunarpPersona
    {
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
    }
}
