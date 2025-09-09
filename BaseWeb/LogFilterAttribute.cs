
using Newtonsoft.Json;
using OpenB.BL;
using OpenB.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OpenB.BaseWeb
{
    public class LogSEDI : ActionFilterAttribute
    {
        public int ServicioId { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            Controller controller = filterContext.Controller as Controller;
            try
            {
                if (controller.User.Identity.IsAuthenticated)
                {
                    var username = HttpContext.Current.User.Identity.Name;
                    var url = filterContext.HttpContext.Request.RawUrl;
                    string urlreferrer = filterContext.HttpContext.Request.Url.ToString();

                    string controlador = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    string action = filterContext.ActionDescriptor.ActionName;
                    string usersipaddress = filterContext.HttpContext.Request.UserHostAddress;
                    string metodo = HttpContext.Current.Request.HttpMethod;

                    string customtag = ObjToQueryString(filterContext.ActionParameters.Values);

                    HttpRequestBase request = filterContext.HttpContext.Request;

                    string requestheaders = request.ServerVariables.Get("HTTP_USER_AGENT");
                    int statuscode = filterContext.HttpContext.Response.StatusCode;

                    LogBE log = new LogBE();

                    log.Id_Sistema = ServicioId;
                    log.Duration = 0;
                    log.Url = url;
                    log.UrlTemplate = "";
                    log.UrlReferrer = urlreferrer;
                    log.IPAddress = usersipaddress;
                    log.ControllerName = controlador;
                    log.MethodName = action;
                    log.HttpMethod = metodo;
                    log.Flags = 0;
                    log.CustomTags = customtag;
                    log.RequestHeaders = requestheaders;
                    log.RequestBody = "";
                    log.RequestSize = 0;
                    log.RequestObjectCount = 0;
                    log.HttpStatus = statuscode;
                    log.ResponseHeaders = "";
                    log.ResponseBody = "";
                    log.ResponseSize = 0;
                    log.ResponseObjectCount = 0;
                    log.LocalLog = "";
                    log.Error = "";
                    log.ErrorDetails = "";
                    log.UserName = username;
                    log.Tipo = "N";

                    LogBL.LogSEDI(log);

                    return;
                }
            }
            catch
            {
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        string ObjToQueryString(object obj)
        {
            var step1 = JsonConvert.SerializeObject(obj);
            return string.Join("&", step1);
        }
    }
}