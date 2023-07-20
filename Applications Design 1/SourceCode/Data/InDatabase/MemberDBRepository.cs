
using DataInterfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InDatabase
{
    public class MemberDBRepository : IMemberRepository
    {
        public Member AddMemberToMemberRepository(Member aMember)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Member MemberDB = SearchMemberById(aMember.Id);
                if (MemberDB != null)
                {
                    throw new MemberRepoException("Member already exists");
                }
                else
                {
                    dbContext.Members.Add(aMember);
                    dbContext.SaveChanges();
                }

                return aMember;
            }
        }

        public void DeleteMember(int id)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Member res = dbContext.Members.Include("DirectMovies").FirstOrDefault(x => x.Id == id);

                if (res == null)
                {
                    throw new MemberRepoException("Member does not exists");
                }
                else
                {
                    if (res.Type == MemberType.ActorAndDirector) {
                        List<ActingRole> roles = dbContext.ActingRoles.Where(x => x.Member.Id == res.Id).ToList();
                        if (roles.Count > 0 || res.DirectMovies.Count > 0) {
                            throw new MemberRepoException("Member Has directed Movies or acting roles,  please delete them");
                        }
                  
                    }
                    else if (res.Type == MemberType.Actor)
                    {
                        List<ActingRole> roles = dbContext.ActingRoles.Where(x => x.Member.Id == res.Id).ToList();
                        if (roles.Count>0)
                        {
                            throw new MemberRepoException("Member Has Acting roles, please delete them");
                        }
                    }
                    else
                    {
                        if (res.DirectMovies.Count > 0) {
                            throw new MemberRepoException("Member Has directed Movies,  please delete them");
                        }

                    }
                    dbContext.Entry(res).State = System.Data.Entity.EntityState.Deleted;
                    dbContext.Members.Remove(res);
                    dbContext.SaveChanges();
                }

            }
        }

        public IList<Member> GetAllMembers()
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Members.ToList();
            }
        }

        public Member SearchMemberById(int id)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Members.FirstOrDefault(x => x.Id == id);
            }
        }

        public Member ModifyMemberProfileImage(int idMember, String pathProfileImage)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Member memberDb=dbContext.Members.FirstOrDefault(x => x.Id == idMember);
                if (memberDb != null)
                {
                    memberDb.ProfilePicture = pathProfileImage;
                    dbContext.SaveChanges();
                    return memberDb;
                }
                else
                {
                    throw new MemberRepoException("Couldnt find a member with that id");
                }
            }

        }
    }
}
