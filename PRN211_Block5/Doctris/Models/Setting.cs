using System;
using System.Collections.Generic;

namespace Doctris.Models
{
    public partial class Setting
    {
        public Setting()
        {
            Dayofweeks = new HashSet<Dayofweek>();
            UserRoles = new HashSet<UserRole>();
        }

        public int SettingId { get; set; }
        public string SettingType { get; set; } = null!;
        public string SettingName { get; set; } = null!;
        public string? SettingDescription { get; set; }

        public virtual ICollection<Dayofweek> Dayofweeks { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
