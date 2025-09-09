using OpenB.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.ViewModel
{
    public class HomeReporteVM
    {
        public List<ReporteTopTenBE> topten { get; set; }
        public ReporteIndicadorBE indicadores { get; set; }
    }
}
