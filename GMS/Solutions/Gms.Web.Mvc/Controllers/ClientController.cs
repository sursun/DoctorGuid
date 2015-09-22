using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
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

        [Transaction]
        public ActionResult ClientInfo(string mac, string ip)
        {
            try
            {
                Terminal terminal = this.TerminalRepository.GetBy(mac);

                if (terminal == null)
                {
                    terminal = new Terminal();
                }

                terminal.CurIp = ip;
                terminal.Mac = mac;

                terminal = this.TerminalRepository.SaveOrUpdate(terminal);

                return JsonSuccess(terminal);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 上传屏幕截屏
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Screen([ModelBinder(typeof(HttpPostedFileBaseModelBinder))] HttpPostedFileBase file)
        {
            if (CurrentUser == null)
            {
                return Empty();
            }


            //保存到当前机器目录下
            var mac = Request.GetMac();
            var upfile = Request.Files[0];


            var pcScreenPath = Server.MapPath(string.Format("~/Content/PCFiles/{0}/Screen", mac));
            if (!Directory.Exists(pcScreenPath))
            {
                Directory.CreateDirectory(pcScreenPath);
            }
            pcScreenPath = Path.Combine(pcScreenPath, "screen.png");

            upfile.SaveAs(pcScreenPath);


            //保存到当前人员目录下
            if (CurrentUser != null)
            {
                var userScreenPath = Server.MapPath(string.Format("~/Content/UserFiles/{0}/Screen/", CurrentUser.Id));
                if (!Directory.Exists(userScreenPath))
                {
                    Directory.CreateDirectory(userScreenPath);
                }

                System.IO.File.Copy(pcScreenPath, Path.Combine(userScreenPath, "screen.png"), true);

            }
            return Empty();
        }

    }



}
