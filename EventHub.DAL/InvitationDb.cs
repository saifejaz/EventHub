using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.DAL
{
    public class InvitationDb
    {
        private OurDbContext db;

        public InvitationDb()
        {
            db = new OurDbContext();
        }

        public IEnumerable<Invitation> GetALL()
        {
            return db.Invitations.ToList();
        }

        public Invitation GetByID(int id)
        {
            return db.Invitations.Find(id);
        }

        public Invitation GetByEmail(string email)
        {
            return db.Invitations.Where(x => x.Email == email).FirstOrDefault();
        }

        public void Insert(Invitation testInvitation)
        {
            db.Invitations.Add(testInvitation);
            Save();
        }

        public void Delete(int id)
        {
            Invitation testInvitation = db.Invitations.Find(id);
            db.Invitations.Remove(testInvitation);
            Save();
        }

        public void Update(Invitation testInvitation)
        {
            db.Entry(testInvitation).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
