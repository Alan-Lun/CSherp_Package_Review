using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Automapper.Service;

namespace Console_Automapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberService = new MemberService();
            var member = memberService.GetMember();
            Console.WriteLine(member.ID);
            Console.WriteLine(member.UserName);
            Console.WriteLine(member.Birthday.Date);
            Console.Read();
        }
    }
}
