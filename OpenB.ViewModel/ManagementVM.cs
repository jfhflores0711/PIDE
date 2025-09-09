using OpenB.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.ViewModel
{
    public class VMRoles
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public List<Eroles> rows { get; set; }
    }

    public class VMUsuarios
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public List<UsuariomBE> rows { get; set; }
    }
}
