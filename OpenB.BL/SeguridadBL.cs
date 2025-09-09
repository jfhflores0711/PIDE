using OpeB.DA;
using OpenB.Entidad;
using OpenB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BL
{
    public class SeguridadBL: ISeguridadAPP
    {

        public SeguridadVM AutenticarUsuario(int tipo, string usuario, string password, string ip, string navegador)
        {
            UsuarioBE usuarioBE = SeguridadDA.AutenticarUsuario(tipo, usuario, password, ip, navegador);
            
            SeguridadVM seguridadVM = new SeguridadVM();
            if (usuarioBE != null)
            {
                seguridadVM.PerfilBE = SeguridadDA.RolUsuario(usuario); 
            }
            seguridadVM.UsuarioBE = usuarioBE;
            return seguridadVM;
        }

        public void CargarSesion(SeguridadVM seguridadVM)
        {
            SeguridadDA s = new SeguridadDA();
            var session = new SessionBE();

                session = new SessionBE()
                {
                    IdUsuario = seguridadVM.UsuarioBE.n_id_usuario,
                    ApellidoPaterno = seguridadVM.UsuarioBE.c_appaterno,
                    ApellidoMaterno = seguridadVM.UsuarioBE.c_apmaterno,
                    Nombres = seguridadVM.UsuarioBE.c_nombres,
                    NombreCompleto = String.Format("{0} {1} {2}", seguridadVM.UsuarioBE.c_nombres, seguridadVM.UsuarioBE.c_appaterno, seguridadVM.UsuarioBE.c_apmaterno),
                    NroDocumento = seguridadVM.UsuarioBE.c_dni
                };
            var x = session;
        }


        public void RegistrarLogin(string usuario, string ip, string navegador, string tipo, string fuente)
        {
            new SeguridadDA().RegistrarLogin(usuario, ip, navegador, tipo, fuente);
            
        }

        public void CerrarSesion()
        {
            var session = new SessionBE()
            {
                IdUsuario = 0,
                ApellidoPaterno = null,
                ApellidoMaterno = null,
                Nombres = null,
                NombreCompleto = null,
                NroDocumento = null,
                Flag = false
            };

        }
    }
}
