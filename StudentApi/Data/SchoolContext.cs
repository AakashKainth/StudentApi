// Data/SchoolContext.cs
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;
using System.Collections.Generic;

namespace StudentApi.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}