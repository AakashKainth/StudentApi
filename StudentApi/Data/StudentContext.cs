// Data/SchoolContext.cs
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;
using System.Collections.Generic;

namespace StudentApi.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}