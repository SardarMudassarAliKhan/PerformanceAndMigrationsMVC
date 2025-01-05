﻿namespace PerformanceAndMigrationsMVC.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
