using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class UserRole
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }

        public virtual Setting Role { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
