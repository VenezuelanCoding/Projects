using Data.InDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public static class DbCleanUp
    {

        public static void DbCleanup()
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                //Aca eliminar en el orden correcto que deja la base de datos
                dbContext.Database.ExecuteSqlCommand("DELETE FROM SCORES");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM WATCHEDBY");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM SUPERLIKEDBY");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM LIKEDBY");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM RELATEDMOVIES");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM HASSUBGENRES");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM DISLIKEDBY");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM DIRECTS");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM ACTINGROLES");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM MEMBERS");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM MOVIES");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM PROFILES");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM GENRES");
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlCommand("DELETE FROM ACCOUNTS");
                dbContext.SaveChanges();

            }

        }
    }
}
