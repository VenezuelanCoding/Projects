using DataInterfaces;
using LogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class MemberLogic : IMemberLogic
    {
        private IMemberRepository _repository;
        public MemberLogic(IMemberRepository repo)
        {
            _repository = repo;
        }

        public Member AddNewMember(Member aMember, Account currentAccount)
        {
            if (currentAccount.isAdmin) {
                return _repository.AddMemberToMemberRepository(aMember);
            }
            else
            {
                throw new PermissionDeniedException("You cant access this function with your privileges");
            }
        }

        public void DeleteMember(int Id, Account currentAccount)
        {
            if (currentAccount.isAdmin)
            {
                _repository.DeleteMember(Id);
            }
            else
            {
                throw new PermissionDeniedException("You cant access this function with your privileges");
            }
        }

        public IList<Member> GetAllMembers() 
        { 
            return _repository.GetAllMembers();
        }

        public Member SearchMemberById(int id)
        {
            return _repository.SearchMemberById(id); 
        }

        public Member ModifyMemberProfileImage(int idMember, String pathProfileImage,Account currentAccount)
        {
            if (currentAccount.isAdmin)
            {
                return _repository.ModifyMemberProfileImage(idMember, pathProfileImage);
            }
            else
            {
                throw new PermissionDeniedException("You cant access this function with your privileges");
            }
        }

    }
}
