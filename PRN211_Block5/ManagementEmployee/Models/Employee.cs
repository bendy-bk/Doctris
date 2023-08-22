using System;
using System.Collections.Generic;

namespace ManagementEmployee.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public bool? Gender { get; set; }
        public string? Ethnic { get; set; }
        public string? Phone { get; set; }
        public int? DepartmentCode { get; set; }
        public int? RoleId { get; set; }
        public int? SalaryLevel { get; set; }
        public bool? Isactive { get; set; }

        public virtual Department? DepartmentCodeNavigation { get; set; }
        public virtual Role? Role { get; set; }
        public virtual Salary? SalaryLevelNavigation { get; set; }
    }
}
