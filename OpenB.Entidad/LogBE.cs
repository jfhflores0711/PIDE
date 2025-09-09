using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Entidad
{
    public class LogBE
    {
        public int Id_Sistema { get; set; }
        public int Duration { get; set; }
        public string Url { get; set; }
        public string UrlTemplate { get; set; }
        public string UrlReferrer { get; set; }
        public string IPAddress { get; set; }
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public string HttpMethod { get; set; }
        public int Flags { get; set; }
        public string CustomTags { get; set; }
        public string RequestHeaders { get; set; }
        public string RequestBody { get; set; }
        public Int64 RequestSize { get; set; }
        public int RequestObjectCount { get; set; }
        public int HttpStatus { get; set; }
        public string ResponseHeaders { get; set; }
        public string ResponseBody { get; set; }
        public Int64 ResponseSize { get; set; }
        public int ResponseObjectCount { get; set; }
        public string LocalLog { get; set; }
        public string Error { get; set; }
        public string ErrorDetails { get; set; }
        public string UserName { get; set; }
        public string Tipo { get; set; }
    }
}
