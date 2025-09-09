using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad
{
    public class ReporteMensualLog
    {
        public Int64 NRO { get; set; }
        public int CODIGO_SERVICIO { get; set; }
        public string SERVICIO { get; set; }
        public string URL { get; set; }
        public string IP { get; set; }
        public string DATOS_CONSULTADOS { get; set; }
        public string REQUESTHEADERS { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public string USERNAME { get; set; }
        public string NOMBRE_USUARIO { get; set; }
    }

    public class ReporteTopTenBE
    {
        public string DESCRIPCION { get; set; }
        public string PARAMETROS { get; set; }
        public string FECHA { get; set; }
    }

    public class ReporteIndicadorBE
    {
        public int? Indicador1 { get; set; }
        public int? Indicador2 { get; set; }
        public int? Indicador3 { get; set; }
        public int? Indicador4 { get; set; }
        public ReporteIndicadorBE()
        {
            Indicador1 = 0;
            Indicador2 = 0;
            Indicador3 = 0;
            Indicador4 = 0;
        }
    }

    [Table("parametros")]
    public class parametros
    {
        [Key]
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
    }
}
