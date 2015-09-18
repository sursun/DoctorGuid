using System;
using System.Drawing;
using System.Linq;
using Gms.Common;
using Gms.Domain;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    [HandleError]
    public class ClientController : BaseController
    {

        public ActionResult GetLastVersion()
        {
            var filename = Server.MapPath("~/Content/Client/DoctorGuid.zip");
            return File(filename, "application/zip");
        }

        public ActionResult DownLoader()
        {
            var filename = Server.MapPath("~/Content/Client/HKLoader.zip");
            return File(filename, "application/zip");
        }

    }

}
