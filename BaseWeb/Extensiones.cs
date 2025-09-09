using OpenB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenB.BaseWeb
{
    public static class Extensiones
    {
        public static List<RJ_Error> AllErrors(this ModelStateDictionary modelState)
        {
            var result = from ms in modelState
                         where ms.Value.Errors.Any()
                         let fieldKey = ms.Key
                         let errors = ms.Value.Errors
                         from error in errors
                         select new RJ_Error
                         {
                             FieldKey = fieldKey,
                             ErrorMessage = error.ErrorMessage,
                             ExceptionMessage = (error.Exception == null) ? "" : error.Exception.Message
                         };

            return result.ToList();
        }
    }
}