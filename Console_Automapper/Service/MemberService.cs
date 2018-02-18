using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Automapper.Automapper;
using Console_Automapper.Model;

namespace Console_Automapper.Service
{
    public class MemberService
    {
        public MemberService()
        {
            
        }

        /// <summary>
        /// 取得會員
        /// </summary>
        /// <returns>MemberMapper.</returns>
        public MemberMapper GetMember()
        {
            var memberProfile = new MemberProfile();
            //建立mapper
            var mapper = memberProfile.CreateMapper();

            //第一種建立實體
            //var memberModel = new Member()
            //{
            //    id = 1,
            //    Birthday = new DateTime(1990, 01, 01),
            //    UserName = "Test"
            //};
            
            //var member = mapper.Map<Member, MemberMapper>(memberModel);
            //return member;

            //第二種現有實體對應
            var member = new Member()
            {
                id=1,
                UserName = "Test2",
                Birthday = new DateTime(1990,1,1),
            };
            var memberMapper = new MemberMapper();

            mapper.Map(member, memberMapper);
            return memberMapper;
        }

    }
}
