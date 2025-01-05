namespace PerformanceAndMigrationsMVC.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }


    }
}
