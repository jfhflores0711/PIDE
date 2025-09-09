using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using OpenB.BL;
using OpenB.Helper;

namespace OpenB.Site.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {

        public ActionResult homereport()
        {
            HomeReporteBL reportehome = new HomeReporteBL();
            return Json(reportehome.getHomeData(User.Identity.Name), JsonRequestBehavior.AllowGet);
        }


        public void reportelogmensualCSV(int anio, int mes)
        {
            HomeReporteBL reportehome = new HomeReporteBL();

            var sb = new StringBuilder();

            var list = reportehome.getReporteLog(anio, mes);

            //sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", "NRO", "CODIGO DE SERVICIO", "SERVICIO ", "URL", "IP", "DATOS CONSULTADOS", "REQUESTHEADERS", "FECHA_REGISTRO", "USERNAME", "NOMBRE USUARIO", Environment.NewLine);

            //foreach (var item in list)
            //{
            //    sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", item.NRO, item.CODIGO_SERVICIO, item.SERVICIO, item.URL, item.IP, item.DATOS_CONSULTADOS, item.REQUESTHEADERS,item.FECHA_REGISTRO, item.USERNAME, item.NOMBRE_USUARIO, Environment.NewLine);
            //}

            //var response = System.Web.HttpContext.Current.Response;
            //response.BufferOutput = true;
            //response.Clear();
            //response.ClearHeaders();
            //response.ContentEncoding = Encoding.Unicode;
            //response.AddHeader("content-disposition", "attachment;filename=reportelog"+anio.ToString()+mes.ToString()+".CSV ");
            //response.ContentType = "text/plain";
            //response.Write(sb.ToString());
            //response.End();
        }

        public FileResult reportelogmensual(int anio, int mes)
        {
            HomeReporteBL reportehome = new HomeReporteBL();

            var sb = new StringBuilder();

            var list = reportehome.getReporteLog(anio, mes);
            DataTable dt = new DataTable("ReporteLog");

            dt = General.ConvertToDataTable(list);


            using (XLWorkbook wb = new XLWorkbook())
            {
                dt.TableName = "ReporteLog";
                wb.Worksheets.Add(dt);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteLog" + anio.ToString() + mes.ToString() + ".xlsx");
                }
            }
        }

    }
}