using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicInterfaces
{
    public interface IMemberLogic
    {
        void DeleteMember(int Id, Account currentAccount);

        Member AddNewMember(Member aMember, Account currentAccount);

        IList<Member> GetAllMembers();

        Member SearchMemberById(int id);
        Member ModifyMemberProfileImage(int idMember, String pathProfileImage, Account currentAccount);

    }
}
