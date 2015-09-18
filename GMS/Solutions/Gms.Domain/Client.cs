using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class Client:Entity
    {
        /// <summary>
        /// 所属部门
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// 客户机名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Mac地址
        /// </summary>
        public virtual string Mac { get; set; }

        /// <summary>
        /// 指定的IP地址
        /// </summary>
        public virtual string Ip { get; set; }

        /// <summary>
        /// 当前IP
        /// </summary>
        public virtual string CurIp { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public virtual DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
