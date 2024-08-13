using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Users
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
