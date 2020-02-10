using EventHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.BLL
{
    public class ListEventBs
    {
        private ListEventDb objDb;

        public ListEventBs()
        {
            objDb = new ListEventDb();
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
