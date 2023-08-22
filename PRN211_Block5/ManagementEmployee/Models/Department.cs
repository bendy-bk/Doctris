using System;
using System.Collections.Generic;

namespace ManagementEmployee.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
