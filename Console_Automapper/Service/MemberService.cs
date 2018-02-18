using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Automapper.Model;

namespace Console_Automapper.Service
{
    public class MemberService
    {
        public MemberService()
        {
            
        }

        public MemberMapper GetMember()
        {
            return new MemberMapper();
        }

    }
}
