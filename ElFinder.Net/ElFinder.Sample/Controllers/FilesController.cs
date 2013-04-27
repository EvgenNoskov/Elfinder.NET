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
        private Connector _connector;

        public Connector Connector
        {
            get
            {
                if (_connector == null)
                {
                    FileSystemDriver driver = new FileSystemDriver();
                    driver.AddRoot(new Root(new DirectoryInfo(@"C:\Program Files"), "/Program Files/") { IsReadOnly = true });
                    driver.AddRoot(new Root(new DirectoryInfo(Server.MapPath("~/Files")), "/Files/") { Alias = "My documents", StartPath = new DirectoryInfo(Server.MapPath("~/Files/новая папка")) });                    
                    _connector = new Connector(driver); 
                }
                return _connector;
            }
        }
        public ActionResult Index()
        {
            return Connector.Process(this.HttpContext.Request);
        }

        public ActionResult SelectFile(string target)
        {
            return Json(Connector.GetFileByHash(target).FullName);
        }
    }
}
