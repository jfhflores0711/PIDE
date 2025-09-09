using OpeB.DA.reportes;
using OpenB.Entidad;
using OpenB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BL
{
    public class HomeReporteBL
    {
        public List<ReporteMensualLog> getReporteLog(int anio, int mes)
        {
            return reportesDA.getReporteLog(anio, mes);
        }

        public HomeReporteVM getHomeData(string usuario)
        {
            HomeReporteVM homedataVM = new HomeReporteVM();
            homedataVM.topten = reportesDA.getTopTenProductos(usuario);
            homedataVM.indicadores = reportesDA.getIndicadores();
            return homedataVM;
        }

        public static List<parametros> getListaParametro(string categoria)
        {
            return reportesDA.getListaParametro(categoria);
        }

    }
}
