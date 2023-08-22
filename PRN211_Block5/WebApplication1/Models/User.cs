using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class User
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Avatar { get; set; }
        public bool? Gender { get; set; }
        public string? Experience { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
