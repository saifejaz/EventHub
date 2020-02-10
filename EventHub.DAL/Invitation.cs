using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.DAL
{
    public class Invitation
    {
        public int InvitationID { get; set; }
        public string Email { get; set; }

        public int EventID { get; set; }
        public virtual Event Event { get; set; }
    }
}
