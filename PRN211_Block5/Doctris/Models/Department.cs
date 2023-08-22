using System;
using System.Collections.Generic;

namespace Doctris.Models
{
    public partial class Department
    {
        public Department()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DepartmentId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
