using EventHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.BLL
{
    public class UserBs
    {
        private UserDb objDb;

        public UserBs()
        {
            objDb = new UserDb();
        }

        public IEnumerable<User> GetALL()
        {
            return objDb.GetALL();
        }

        public User GetByID(int id)
        {
            return objDb.GetByID(id);
        }

        public void Insert(User testUser)
        {
            objDb.Insert(testUser);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(User testUser)
        {
            objDb.Update(testUser);
        }
    }
}
