using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad
{
    public class UsuarioBE
    {
        public int n_id_usuario { get; set; }
        public string c_login { get; set; }
        public string c_dni { get; set; }
        public string c_appaterno { get; set; }
        public string c_apmaterno { get; set; }
        public string c_nombres { get; set; }
        public string c_nombrec { get; set; }
    }

    public class UsuariomBE : UsuarioBE
    {
        public Int64 NRO { get; set; }
        public string c_cargo { get; set; }
        public bool n_estado { get; set; }
        public string c_estado { get; set; }
        public int n_usuario_crea { get; set; }
    }

    public class PerfilBE
    {
        public int n_id_usuario { get; set; }
        public int n_id_perfil { get; set; }
        public string perfil { get; set; }

    }
}
