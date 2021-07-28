using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoHu.Web.Code.Model.System
{
    public class SystemDataVM
    {
        /// <summary>
        /// 当前操作系统
        /// </summary>
        public string System{ get; set; }
        /// <summary>
        /// 操作系统位数
        /// </summary>
        public int  Bit{ get; set; }
    }
}
