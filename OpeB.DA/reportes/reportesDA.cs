using OpenB.DA;
using OpenB.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeB.DA.reportes
{
    public class reportesDA
    {
        public static List<ReporteMensualLog> getReporteLog(int anio, int mes)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<ReporteMensualLog>("exec USP_SEL_REPORTE_AUDITORIA_MENSUAL @anio, @mes",
                     new SqlParameter("anio", anio),
                     new SqlParameter("mes", mes)
                    ).ToList();
                return data;
            }
        }

        public static List<ReporteTopTenBE> getTopTenProductos(string usuario)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<ReporteTopTenBE>("exec [seguridad].[USP_SEL_CI_TOP10] @id",
                     new SqlParameter("id", usuario)
                    ).ToList();
                return data;
            }
        }

        public static ReporteIndicadorBE getIndicadores()
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.SqlQuery<ReporteIndicadorBE>("exec [webseguridad].[USP_SEL_CI_INDICADORES]"
                    ).FirstOrDefault();
                return data;
            }
        }

        public static List<parametros> getListaParametro(string categoria)
        {
            using (db_openbContext context = new db_openbContext())
            {
                return context.parametros.Where(x => x.Categoria == categoria).ToList<parametros>();
            }
        }
    }
}
