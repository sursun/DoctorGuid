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
    public class TerminalController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(TerminalQuery query)
        {
            var list = this.TerminalRepository.GetList(query);
            var data = list.Data.Select(c => TerminalModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }
        
    }


    public class TerminalModel
    {
        public TerminalModel(Terminal terminal)
        {
            this.Id = terminal.Id;
            this.DepartmentName = terminal.Department != null ? terminal.Department.Name : "";
            this.Name = terminal.Name;
            this.Mac = terminal.Mac;
            this.Ip = terminal.Ip;
            this.CurIp = terminal.CurIp;
            this.LastLoginTime = terminal.LastLoginTime.ToJsonString();
            this.Note = terminal.Note;
            this.CreateTime = terminal.CreateTime.ToJsonString();
        }

        public int Id { get; set; }

        //// <summary>
        /// 所属部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 客户机名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Mac地址
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// 指定的IP地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 当前IP
        /// </summary>
        public string CurIp { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public string LastLoginTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string CreateTime { get; set; }

        public static TerminalModel From(Terminal terminal)
        {
            return new TerminalModel(terminal);
        }
    }


}
