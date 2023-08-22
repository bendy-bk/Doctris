using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class DoctrisContext : DbContext
    {
        public DoctrisContext()
        {
        }

        public DoctrisContext(DbContextOptions<DoctrisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Dayofweek> Dayofweeks { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = Doctris ;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Doctor).HasColumnName("doctor");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__appointme__depar__33D4B598");

                entity.HasOne(d => d.DoctorNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Doctor)
                    .HasConstraintName("FK__appointme__docto__34C8D9D1");
            });

            modelBuilder.Entity<Dayofweek>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__dayofwee__2370F727670E6F56");

                entity.ToTable("dayofweek");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.SettingId).HasColumnName("setting_id");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.HasOne(d => d.Setting)
                    .WithMany(p => p.Dayofweeks)
                    .HasForeignKey(d => d.SettingId)
                    .HasConstraintName("FK__dayofweek__setti__2F10007B");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("setting");

                entity.Property(e => e.SettingId)
                    .ValueGeneratedNever()
                    .HasColumnName("setting_id");

                entity.Property(e => e.SettingDescription)
                    .HasMaxLength(255)
                    .HasColumnName("setting_description");

                entity.Property(e => e.SettingName)
                    .HasMaxLength(30)
                    .HasColumnName("setting_name");

                entity.Property(e => e.SettingType)
                    .HasMaxLength(30)
                    .HasColumnName("setting_type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserName, "UQ__user__7C9273C46C1E4263")
                    .IsUnique();

                entity.HasIndex(e => e.Mobile, "UQ__user__A32E2E1C24712A3F")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__user__AB6E61641BEC5A87")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("avatar");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Experience)
                    .HasColumnType("text")
                    .HasColumnName("experience");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mobile")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId })
                    .HasName("PK__user_rol__9D9286BC9F6B00E3");

                entity.ToTable("user_role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_role__role___2B3F6F97");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_role__user___2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
