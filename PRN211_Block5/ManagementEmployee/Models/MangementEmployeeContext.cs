using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManagementEmployee.Models
{
    public partial class MangementEmployeeContext : DbContext
    {
        public MangementEmployeeContext()
        {
        }

        public MangementEmployeeContext(DbContextOptions<MangementEmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server = BENDY; database = MangementEmployee ;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AFB3EC6D49C46226");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .HasColumnName("address");

                entity.Property(e => e.DepartmentCode).HasColumnName("departmentCode");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(150)
                    .HasColumnName("empName");

                entity.Property(e => e.Ethnic)
                    .HasMaxLength(50)
                    .HasColumnName("ethnic");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.SalaryLevel).HasColumnName("salaryLevel");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.DepartmentCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentCode)
                    .HasConstraintName("FK__Employee__depart__2A4B4B5E");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Employee__roleID__2B3F6F97");

                entity.HasOne(d => d.SalaryLevelNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SalaryLevel)
                    .HasConstraintName("FK__Employee__salary__2C3393D0");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(150)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.SalaryLevel)
                    .HasName("PK__salary__83BC72D83105D29D");

                entity.ToTable("salary");

                entity.Property(e => e.SalaryLevel).HasColumnName("salaryLevel");

                entity.Property(e => e.Coefficient).HasColumnName("coefficient");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
