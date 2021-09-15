using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdaptItAcademy.DataAccess.Models
{
    public partial class AdaptItAcademyContext : DbContext
    {
        public AdaptItAcademyContext()
        {
        }

        public AdaptItAcademyContext(DbContextOptions<AdaptItAcademyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Delegates> Delegates { get; set; }
        public virtual DbSet<TrainingRegistration> TrainingRegistrations { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainingCourseTotalAmount> TrainingCourseTotalAmount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CourseDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Delegates>(entity =>
            {
                entity.ToTable("Delegate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DietaryRequirements)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrainingRegistration>(entity =>
            {
                entity.ToTable("TrainingRegistration");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DelegateId).HasColumnName("DelegateID");
 
                entity.Property(e => e.TrainingId).HasColumnName("TrainingID");

            });

            modelBuilder.Entity<TrainingCourseTotalAmount>(entity =>
            {
                entity.ToTable("TrainingCourseTotalAmount");

                entity.Property(e => e.TrainingId).HasColumnName("TrainingID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("Training");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.RegistrationClosingDate).HasColumnType("datetime");

                entity.Property(e => e.TrainingCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalTrainingCostPaid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TrainingDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentRequired).HasColumnType("boolean");

                entity.Property(e => e.TrainingVenue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Training__Course__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
