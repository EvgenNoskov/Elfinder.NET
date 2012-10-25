using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElFinder.DTO
{
    internal static class Error
    {       
        public static JsonResult CommandNotFound()
        {
            return Json(new { error = "errUnknownCmd" });
        }
        public static JsonResult MissedParameter(string command)
        {
            return Json(new { error = new string[] { "errCmdParams", command } });
        }
        private static JsonResult Json(object data)
        {
            return new JsonDataContractResult(data) { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}