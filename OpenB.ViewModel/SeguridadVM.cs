using OpenB.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.ViewModel
{
    public class SeguridadVM
    {
        public UsuarioBE UsuarioBE { get; set; }
        public List<PerfilBE> PerfilBE { get; set; }
        public SessionBE SessionBE { get; set; }

        public SeguridadVM()
        {
            UsuarioBE = new UsuarioBE();
            SessionBE = new SessionBE();  //Miembro heredado
            PerfilBE = new List<PerfilBE>();
        }
    }


}
