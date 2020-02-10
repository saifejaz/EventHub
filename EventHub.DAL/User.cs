using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.DAL
{
    //public class UniqueUsernameAttribute : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        OurDbContext db = new OurDbContext();
    //        string usernameValue = value.ToString();
    //        int count = db.Users.Where(x => x.UserName == usernameValue).ToList().Count();
    //        if (count != 0)
    //            return new ValidationResult("Username already exists");
    //        return ValidationResult.Success;
    //    }
    //}

    //public class UniqueEmailAttribute : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        OurDbContext db = new OurDbContext();
    //        string emailValue = value.ToString();
    //        int count = db.Users.Where(x => x.UserName == emailValue).ToList().Count();
    //        if (count != 0)
    //            return new ValidationResult("Email already exists");
    //        return ValidationResult.Success;
    //    }
    //}

    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        //[UniqueUsername]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email address")]
        //[UniqueEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
