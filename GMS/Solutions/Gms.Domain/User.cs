using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class User : Entity
    {
        public User()
        {
            this.CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 所属科室
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// 职工编号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public virtual String LoginName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Guid MemberShipId { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual String RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual String NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual String Mobile { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        public virtual String ProfessionalLevel { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public virtual String Duty { get; set; }

        /// <summary>
        /// 启用|禁用
        /// </summary>
        public virtual Enabled Enabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }

    public class UserQuery : QueryBase
    {

    }
}
