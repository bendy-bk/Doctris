using System;
using System.Collections.Generic;

namespace ManagementEmployee.Models
{
    public partial class Salary
    {
        public Salary()
        {
            Employees = new HashSet<Employee>();
        }

        public int SalaryLevel { get; set; }
        public int? Coefficient { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
