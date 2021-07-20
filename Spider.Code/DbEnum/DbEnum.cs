using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Code.DbEnum
{
    public enum StatusEnum
    {
        /// <summary>
        /// 启用
        /// </summary>
        Start,
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled,
        /// <summary>
        /// 冻结
        /// </summary>
        Freeze
    }
    public enum PowerEnum
    {
        /// <summary>
        /// 管理员
        /// </summary>
        Manage,

        /// <summary>
        /// 普通用户
        /// </summary>
        Common
    }
}
