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
    public class rolesDA
    {
        public static VMRoles getListaRoles(Busqueda_Param m)
        {
            VMRoles res = new VMRoles();
            using (db_openbContext context = new db_openbContext())
            {
                using (var connection = context.Database.Connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[interop].[USP_SEL_ROLES_PAGINACION]";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Tipo", 1));
                    command.Parameters.Add(new SqlParameter("@page", m.page));
                    command.Parameters.Add(new SqlParameter("@limit", m.rows));
                    command.Parameters.Add(new SqlParameter("@sidx", m.sidx));
                    command.Parameters.Add(new SqlParameter("@sord", m.sord));

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
                                     .Translate<Eroles>(reader)
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

    }
}
