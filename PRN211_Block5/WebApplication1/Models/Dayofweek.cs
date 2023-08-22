using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Dayofweek
    {
        public int EventId { get; set; }
        public int? SettingId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public virtual Setting? Setting { get; set; }
    }
}
