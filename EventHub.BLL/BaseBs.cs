using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.BLL
{
    public class BaseBs
    {
        public UserBs userBs { get; set; }

        public EventBs eventBs { get; set; }

        public ListEventBs listEventBs { get; set; }

        public BaseBs()
        {
            userBs = new UserBs();
            eventBs = new EventBs();
            listEventBs = new ListEventBs();
        }
    }
}
