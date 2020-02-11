using EventHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.BLL
{
    public class InvitationBs
    {
        private InvitationDb objDb;

        public InvitationBs()
        {
            objDb = new InvitationDb();
        }

        public IEnumerable<Invitation> GetALL()
        {
            return objDb.GetALL();
        }

        public Invitation GetByID(int id)
        {
            return objDb.GetByID(id);
        }

        public Invitation GetByEmail(string email)
        {
            return objDb.GetByEmail(email);
        }

        public void Insert(Invitation testInvitation)
        {
            objDb.Insert(testInvitation);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(Invitation testInvitation)
        {
            objDb.Update(testInvitation);
        }
    }
}
