using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gms.Common;
using Gms.Domain;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            return View();
        }

        public ActionResult List(UserQuery query)
        {
            var list = this.UserRepository.GetList(query);
            var data = list.Data.Select(c => UserModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        public ActionResult Get(int id)
        {
            var user = this.UserRepository.Get(id);
            return JsonSuccess(user ?? (new User()));
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            var item = UserRepository.Get(id);
            if (item != null)
            {
                Membership.DeleteUser(item.LoginName);

                UserRepository.Delete(item);
            }

            return JsonSuccess();
        }

        [Transaction]
        public ActionResult CreateOrUpdate(User user, string psw)
        {
            try
            {
                if (user.Id <= 0)
                {
                    string strUserName = user.CodeNo.Trim();

                    MembershipUser membershipuser = Membership.GetUser(strUserName);

                    if (membershipuser != null)
                    {
                        throw new Exception("工号[" + strUserName + "]已经存在!");
                    }

                    membershipuser = Membership.CreateUser(strUserName, psw);

                    user.MemberShipId = (Guid)membershipuser.ProviderUserKey;
                    user.CreateTime = membershipuser.CreationDate;
                    user.LoginName = user.CodeNo;
                }
                else
                {
                    user = this.UserRepository.Get(user.Id);

                    TryUpdateModel(user);
                }

                user = this.UserRepository.SaveOrUpdate(user);

                return JsonSuccess(user);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        public ActionResult ResetPassword(int id)
        {
            var user = this.UserRepository.Get(id);
            if (user == null)
                return JsonError("没有找到用户，请刷新后再试！");
            MembershipUser membershipUser = Membership.GetUser(user.LoginName);
            string tempPsw = membershipUser.ResetPassword();
            string defaultPassword = "123";
            try
            {
                membershipUser.ChangePassword(tempPsw, defaultPassword);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonSuccess(defaultPassword);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ChangePsw(string oldpsw,string newpsw)
        {
            MembershipUser membershipUser = Membership.GetUser(MembershipId);

            try
            {
                if (membershipUser == null)
                {
                    throw new Exception("没有找到用户");
                }

                bool bFlag = membershipUser.ChangePassword(oldpsw, newpsw);

                if (!bFlag)
                {
                    return JsonError("原密码不正确");
                }
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonSuccess();
        }

    }

    public class UserModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public String LoginName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public String RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public String NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public String GenderStr { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile { get; set; }

        /// <summary>
        /// 启用|禁用
        /// </summary>
        public String EnabledStr { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public String CreateTime { get; set; }

        public UserModel(User user) 
        {
            this.Id = user.Id;

            this.LoginName = user.LoginName;
            this.RealName = user.RealName;
            this.NickName = user.NickName;
            this.GenderStr = user.Gender.ToString();
            this.Mobile = user.Mobile;
            this.EnabledStr = user.Enabled.ToString();
            this.Note = user.Note;
            
            this.CreateTime = user.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static UserModel From(User user)
        {
            return new UserModel(user);
        }
    }


}
