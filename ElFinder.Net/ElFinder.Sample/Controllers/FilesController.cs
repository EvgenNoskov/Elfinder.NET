using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElFinder;
using System.IO;

namespace ElFinder.Sample.Controllers
{
    public class FilesController : Controller
    {
      
        public ActionResult Index()
        {
            FileSystemDriver driver = new FileSystemDriver();
            driver.AddRoot(new Root(new DirectoryInfo(Server.MapPath("~/Files")), "http://" +  Request.Url.Authority + "/Files/") { IsReadOnly = false, Alias = "Мои документы" });
            driver.AddRoot(new Root(new DirectoryInfo(@"C:\Program Files"), "http://" +  Request.Url.Authority + "/") { IsReadOnly = true });
            var connector = new Connector(driver);  
            return connector.Process(this.HttpContext.Request);
        }

        public ActionResult SelectFile(string target)
        {
            FileSystemDriver driver = new FileSystemDriver();
            driver.AddRoot(new Root(new DirectoryInfo(Server.MapPath("~/Files")), "http://" + Request.Url.Authority + "/Files/") { IsReadOnly = false, Alias = "Мои документы" });
            driver.AddRoot(new Root(new DirectoryInfo(@"C:\Program Files"), "http://" + Request.Url.Authority + "/") { IsReadOnly = true });
            var connector = new Connector(driver);
            return Json(connector.GetFileByHash(target).FullName);
        }

    }
}
