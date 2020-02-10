using EventHub.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.BLL
{
    // Event business class
    public class EventBs
    {
        private EventDb objDb;

        public EventBs()
        {
            objDb = new EventDb();
        }

        public IEnumerable<Event> GetALL()
        {
            return objDb.GetALL();
        }

        public Event GetByID(int id)
        {
            return objDb.GetByID(id);
        }

        public void Insert(Event testEvent)
        {
            objDb.Insert(testEvent);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(Event testEvent)
        {
            objDb.Update(testEvent);
        }

        
    }
}
