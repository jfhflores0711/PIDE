using OpeB.DA.management;
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
    public class managementBL
    {
        //Roles*******************************************************************************************************************************************************************

        public static VMRoles getListaRoles(Busqueda_Param m)
        {
            var r = rolesDA.getListaRoles(m);
            return r;
        }

        //Usuarios*******************************************************************************************************************************************************************

        public static VMUsuarios getListaUsuarios(Busqueda_Param_Usuario m)
        {
            var r = usuarioDA.getListaUsuarios(m);
            return r;
        }

        public static int updUsuario(UsuariomBE m)
        {
            SessionBE p = new SessionBE();
            m.n_usuario_crea = p.IdUsuario;
            return usuarioDA.updUsuario(m);
        }

        public static int setUsuario(ModelUsuario m)
        {
            SessionBE p = new SessionBE();
            m.n_usuario_modifica = p.IdUsuario;
            m.n_id_usuario = (m.n_id_usuario == null ? 0 : m.n_id_usuario);

            return usuarioDA.setUsuario(m);
        }

        public static List<UsuarioRoles> getUsuarioRol(int id)
        {
            return usuarioDA.getUsuarioRol(id);
        }

        public static int setRol(ModelUsuarioRole m)
        {
            SessionBE p = new SessionBE();
            m.i_creado_por = p.IdUsuario;

            return usuarioDA.setRol(m);
        }

        public static int updUsuarioPass(int usuario, string clave_nueva, int n_usuario_modifica)
        {
            SessionBE p = new SessionBE();
            n_usuario_modifica = p.IdUsuario;

            return usuarioDA.updUsuarioPass(usuario, clave_nueva, n_usuario_modifica);
        }

        public static bool ActualizarClave(ModelSegUsuario m)
        {
            SessionBE p = new SessionBE();
            m.id_usuario = p.IdUsuario;

            if (SeguridadDA.ActualizarClave(m) > 0)
            {
                return true;
            }
            else
                return false;

        }
    }
}
