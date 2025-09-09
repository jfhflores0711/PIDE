using OpenB.DA;
using OpenB.Entidad;
using OpenB.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeB.DA.management
{
    public class usuarioDA
    {
        public static VMUsuarios getListaUsuarios(Busqueda_Param_Usuario m)
        {
            VMUsuarios res = new VMUsuarios();
            using (db_openbContext context = new db_openbContext())
            {
                using (var connection = context.Database.Connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[interop].[USP_SEL_USUARIOS_PAGINACION]";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Tipo", 1));
                    command.Parameters.Add(new SqlParameter("@page", m.page));
                    command.Parameters.Add(new SqlParameter("@limit", m.rows));
                    command.Parameters.Add(new SqlParameter("@sidx", m.sidx));
                    command.Parameters.Add(new SqlParameter("@sord", m.sord));

                    command.Parameters.Add(new SqlParameter("@valor_filtro1", m.tipo == 1 ? m.valor : ""));
                    command.Parameters.Add(new SqlParameter("@valor_filtro2", m.tipo == 2 ? m.valor : ""));
                    command.Parameters.Add(new SqlParameter("@valor_filtro3", m.tipo == 3 ? m.valor : ""));
                    command.Parameters.Add(new SqlParameter("@valor_filtro4", m.tipo == 4 ? Convert.ToInt32(m.estado) : 2));

                    using (var reader = command.ExecuteReader())
                    {
                        var records =
                            ((IObjectContextAdapter)context)
                                .ObjectContext
                                .Translate<int>(reader)
                                .FirstOrDefault();

                        res.records = records;

                        reader.NextResult();

                        var lista =
                                 ((IObjectContextAdapter)context)
                                     .ObjectContext
                                     .Translate<UsuariomBE>(reader)
                                     .ToList();

                        res.rows = lista;
                    }

                    int totalPages = (m.rows != 0 ? (int)Math.Ceiling((decimal)res.records / (decimal)m.rows) : 0);
                    res.total = totalPages;
                    res.page = m.page;

                    return res;
                }

            }
        }

        public static int updUsuario(UsuariomBE m)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<int>("exec [interop].[SP_UPD_ANULA_USUARIO] @CODIGO, @n_usuario_modifica",
                    new SqlParameter("CODIGO", m.n_id_usuario),
                    new SqlParameter("n_usuario_modifica", m.n_usuario_crea)).FirstOrDefault();
                return data;
            }
        }

        public static int setUsuario(ModelUsuario m)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<int>("exec [interop].[SP_INS_REGISTRAR_CLIENTE] @n_id_usuario, @c_login, @c_dni, @c_appaterno, @c_apmaterno, @c_nombres, @c_nombrec, @c_cargo, @n_estado, @n_usuario_crea",
                    new SqlParameter("n_id_usuario", m.n_id_usuario),
                    new SqlParameter("c_login", m.c_login),
                    new SqlParameter("c_dni", m.c_dni),
                    new SqlParameter("c_appaterno", m.c_appaterno),
                    new SqlParameter("c_apmaterno", m.c_apmaterno),
                    new SqlParameter("c_nombres", m.c_nombres),
                    new SqlParameter("c_nombrec", m.c_nombrec),
                    new SqlParameter("c_cargo", m.c_cargo),
                    new SqlParameter("n_estado", m.n_estado),
                    new SqlParameter("n_usuario_crea", m.n_usuario_modifica)
                    ).FirstOrDefault();
                return data;
            }
        }

        public static List<UsuarioRoles> getUsuarioRol(int id)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<UsuarioRoles>("exec [interop].[USP_SEL_ROL_ASIGNADO] @id",
                    new SqlParameter("id", id)).ToList();
                return data;
            }
        }

        public static int setRol(ModelUsuarioRole m)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<int>("exec [interop].[USP_DEL_ROL_ASIGNADO] @id, @usuario, @valor, @i_creado_por",
                    new SqlParameter("id", m.i_id_rol),
                    new SqlParameter("usuario", m.i_id_usuario),
                    new SqlParameter("valor", m.valor),
                    new SqlParameter("i_creado_por", m.i_creado_por)
                    ).FirstOrDefault();
                return data;
            }
        }

        public static int updUsuarioPass(int usuario, string clave_nueva, int n_usuario_modifica)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<int>("exec [interop].[USP_UPD_CLAVE_IND] @usuario, @clave_nueva, @n_usuario_modifica",
                    new SqlParameter("usuario", usuario),
                    new SqlParameter("clave_nueva", clave_nueva),
                    new SqlParameter("n_usuario_modifica", n_usuario_modifica)).FirstOrDefault();
                return data;
            }
        }
    }
}
