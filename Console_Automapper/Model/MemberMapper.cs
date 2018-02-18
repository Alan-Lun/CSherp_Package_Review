using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Automapper.Model
{
    /// <summary>
    /// Class MemberMapper.
    /// </summary>
    public class MemberMapper
    {
        /// <summary>
        /// 使用者編號
        /// </summary>
        public int ID { get; set; }
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
