using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Automapper.Model
{
    /// <summary>
    /// Class Member./
    /// </summary>
    public class Member
    {
        /// <summary>
        /// 使用者編號
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
