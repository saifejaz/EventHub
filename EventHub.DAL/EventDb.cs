using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.DAL
{
    public class EventDb
    {
        private OurDbContext db;

        public EventDb()
        {
            db = new OurDbContext();
        }

        public IEnumerable<Event> GetALL()
        {
            return db.Events.ToList();
        }

        public Event GetByID(int id)
        {
            return db.Events.Find(id);
        }

        public void Insert(Event testEvent)
        {
            db.Events.Add(testEvent);
            Save();
        }

        public void Delete(int id)
        {
            Event testEvent = db.Events.Find(id);
            db.Events.Remove(testEvent);
            Save();
        }

        public void Update(Event testEvent)
        {
            db.Entry(testEvent).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
