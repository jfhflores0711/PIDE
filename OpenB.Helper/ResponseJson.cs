using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace OpenB.Helper
{
    public class ResponseJson
    {

        public bool flag { get; set; }
        public string mensaje { get; set; }
        public List<RJ_Error> errores { get; set; }
        public ResponseJson()
        {
            this.errores = new List<RJ_Error>();
        }
    }

    public class RJ_Error
    {
        public string FieldKey { get; set; }
        public string ErrorMessage { get; set; }
        public string ExceptionMessage { get; set; }
    }
    public class oJson<T>
    {
        private T Data;
        public T data
        {
            get { return Data; }
            set { this.Data = value; }
        }
        public bool flag { get; set; }
        public string status { get; set; }
        public string mensaje { get; set; }
        public string css_class { get; set; }
        public bool flag_data { get; set; }
        public List<RJ_Error> errores { get; set; }
        public int clave { get; set; }
        public oJson()
        {
            this.errores = new List<RJ_Error>();
            this.css_class = "alert alert-danger";
        }
    }

}