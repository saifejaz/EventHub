using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.DAL
{
    public class UserDb
    {
        private OurDbContext db;

        public UserDb()
        {
            db = new OurDbContext();
        }

        public IEnumerable<User> GetALL()
        {
            return db.Users.ToList();
        }

        public User GetByID(int id)
        {
            return db.Users.Find(id);
        }

        public User GetByEmail(string email)
        {
            return db.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public void Insert(User testUser)
        {
            db.Users.Add(testUser);
            Save();
        }

        public void Delete(int id)
        {
            User testUser = db.Users.Find(id);
            db.Users.Remove(testUser);
            Save();
        }

        public void Update(User testUser)
        {
            db.Entry(testUser).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
