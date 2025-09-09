using OpenB.DA;
using OpenB.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeB.DA
{
    public class SeguridadDA
    {
        public static int ActualizarClave(ModelSegUsuario m)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<int>("exec [interop].[USP_UPD_CLAVE] @usuario, @clave_antigua, @clave_nueva",
                    new SqlParameter("usuario", m.id_usuario),
                    new SqlParameter("clave_antigua", m.actual),
                    new SqlParameter("clave_nueva", m.nuevo1)).FirstOrDefault();
                return data;
            }
        }

        public static UsuarioBE AutenticarUsuario(int tipo, string usuario, string password, string ip, string navegador)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<UsuarioBE>("exec [webseguridad].[USP_SEL_LOGIN] @tipo, @c_login, @c_password, @c_ip, @c_navegador, @c_host",
                    new SqlParameter("tipo", tipo),
                    new SqlParameter("c_login", usuario),
                    new SqlParameter("c_password", password),
                    new SqlParameter("c_ip", ip),
                    new SqlParameter("c_navegador", navegador),
                    new SqlParameter("c_host","")).FirstOrDefault();
                return data;
            }
        }


        public static List<PerfilBE> RolUsuario(string usuario)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<PerfilBE>("exec [webseguridad].[USP_SEL_USUARIOROL] @usuario",
                    new SqlParameter("usuario", usuario)).ToList();
                return data;
            }
        }

        public int RegistrarLogin(string usuario, string ip, string navegador, string tipo, string fuente)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.ExecuteSqlCommand("exec seguridad.SP_LOG_ACCESO @c_login, @c_ip, @c_usuario_autenticado, @c_host, @c_tipo, @c_fuente",
                    new SqlParameter("c_login", usuario),
                    new SqlParameter("c_ip", ip),
                    new SqlParameter("c_usuario_autenticado", "WEB"),
                    new SqlParameter("c_host", navegador),
                    new SqlParameter("c_tipo", tipo),
                    new SqlParameter("c_fuente", fuente));
                return data;
            }
        }
    }
}
