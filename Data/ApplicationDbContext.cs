using Microsoft.EntityFrameworkCore;
using PerformanceAndMigrationsMVC.Model;

namespace PerformanceAndMigrationsMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add the following code to the OnModelCreating method
            // 1 to 1 Relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            // Add the following code to the OnModelCreating method
            // 1 to Many Relationship
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            // Add the following code to the OnModelCreating method
            // Many to Many Relationship
            modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)  // Student has many Courses
            .WithMany(c => c.Students)  // Course has many Students
            .UsingEntity<Enrollment>(  // Use an intermediate entity (Enrollment) for the many-to-many relationship
                j => j.HasOne(e => e.Course)  // Enrollment has one Course
                    .WithMany(c => c.Enrollments)  // Course has many Enrollments
                    .HasForeignKey(e => e.CourseId) // Foreign Key from Enrollment to Course      
            );

        }


    }
}