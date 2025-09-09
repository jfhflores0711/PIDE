using OpenB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BL
{
    public interface ISeguridadAPP
    {
        SeguridadVM AutenticarUsuario(int tipo, string usuario, string password, string ip, string navegador);

        void CargarSesion(SeguridadVM seguridadVM);

        void RegistrarLogin(string usuario, string ip, string navegador, string tipo, string fuente);

        void CerrarSesion();
    }
}
