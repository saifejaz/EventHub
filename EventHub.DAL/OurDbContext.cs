using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.DAL
{
    public class OurDbContext : DbContext
    {
        // constructor
        // The name of the connection string (which you'll add to the Web.config file later)
        public OurDbContext() : base("OurDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        //method prevents table names from being pluralized.
        // If you didn't do this, the generated tables in the database
        // would be named Students, Courses, and Enrollments.
        // Instead, the table names will be Student, Course, and Enrollment.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
