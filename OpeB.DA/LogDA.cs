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
    public class LogDA
    {
        public static int LogSEDI(LogBE l)
        {
            using (db_openbContext context = new db_openbContext())
            {
                var data = context.Database.ExecuteSqlCommand("exec [interop].[InsertCallLog] " +
                    "@Id_Sistema, " +
                    "@Duration, " +
                    "@Url, " +
                    "@UrlTemplate, " +
                    "@UrlReferrer, " +
                    "@IPAddress, " +
                    "@ControllerName, " +
                    "@MethodName, " +
                    "@HttpMethod, " +
                    "@Flags, " +
                    "@CustomTags, " +
                    "@RequestHeaders, " +
                    "@RequestBody, " +
                    "@RequestSize, " +
                    "@RequestObjectCount, " +
                    "@HttpStatus, " +
                    "@ResponseHeaders, " +
                    "@ResponseBody, " +
                    "@ResponseSize, " +
                    "@ResponseObjectCount, " +
                    "@LocalLog, " +
                    "@Error, " +
                    "@ErrorDetails, " +
                    "@UserName, " +
                    "@Tipo",
                    new SqlParameter("Id_Sistema", l.Id_Sistema),
                    new SqlParameter("Duration", l.Duration),
                    new SqlParameter("Url", l.Url),
                    new SqlParameter("UrlTemplate", l.UrlTemplate),
                    new SqlParameter("UrlReferrer", l.UrlReferrer),
                    new SqlParameter("IPAddress", l.IPAddress),
                    new SqlParameter("ControllerName", l.ControllerName),
                    new SqlParameter("MethodName", l.MethodName),
                    new SqlParameter("HttpMethod", l.HttpMethod),
                    new SqlParameter("Flags", l.Flags),
                    new SqlParameter("CustomTags", l.CustomTags),
                    new SqlParameter("RequestHeaders", l.RequestHeaders),
                    new SqlParameter("RequestBody", l.RequestBody),
                    new SqlParameter("RequestSize", l.RequestSize),
                    new SqlParameter("RequestObjectCount", l.RequestObjectCount),
                    new SqlParameter("HttpStatus", l.HttpStatus),
                    new SqlParameter("ResponseHeaders", l.ResponseHeaders),
                    new SqlParameter("ResponseBody", l.ResponseBody),
                    new SqlParameter("ResponseSize", l.ResponseSize),
                    new SqlParameter("ResponseObjectCount", l.ResponseObjectCount),
                    new SqlParameter("LocalLog", l.LocalLog),
                    new SqlParameter("Error", l.Error),
                    new SqlParameter("ErrorDetails", l.ErrorDetails),
                    new SqlParameter("UserName", l.UserName),
                    new SqlParameter("Tipo", l.Tipo)
                    );
                return data;
            }
        }
    }
}
