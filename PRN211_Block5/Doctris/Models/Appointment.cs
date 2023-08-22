using System;
using System.Collections.Generic;

namespace Doctris.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? Date { get; set; }
        public int? Doctor { get; set; }
        public bool? IsActive { get; set; }

        public virtual Department? Department { get; set; }
        public virtual User? DoctorNavigation { get; set; }
    }
}
