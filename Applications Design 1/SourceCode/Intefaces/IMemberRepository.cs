using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IMemberRepository
    {
        Member AddMemberToMemberRepository(Member aMember);

        IList<Member> GetAllMembers();

        Member SearchMemberById(int id);

        void DeleteMember(int id);
        Member ModifyMemberProfileImage(int idMember, String pathProfileImage);

    }
}
