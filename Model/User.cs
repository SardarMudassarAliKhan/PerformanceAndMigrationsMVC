﻿namespace PerformanceAndMigrationsMVC.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserProfile Profile { get; set; }
    }
}
