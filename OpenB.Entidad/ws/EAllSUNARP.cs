using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad.ws
{
    public class EAllSUNARP
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
    }

    public class ESunarpRazoSocial: EAllSUNARP
    {
        public string JSonRasoSocial { get; set; }
    }

    public class EAsientos : EAllSUNARP
    {
        public string JSonRasoSocial { get; set; }
    }

    public class EOficinas : EAllSUNARP
    {
        public string JSonOficinas { get; set; }
    }
    public class CollectEOficina
    {
        public EOficina oficina { get; set; }
    }

    public class EOficina
    {
        public List<EOficinaObject> oficina { get; set; }
    }
    public class EOficinaObject
    {
        public string codZona { get; set; }
        public string codOficina { get; set; }
        public string descripcion { get; set; }

    }


    public class EVehiculos : EAllSUNARP
    {
        public string JSonVehiculos { get; set; }
    }


}
