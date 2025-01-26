using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Column("Student_Name", TypeName = "varchar(100)")]
        public string FirstName { get; set; }
        [Column("Student_LastName", TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column("Student_Email", TypeName = "varchar(100)")]
        public string Email { get; set; }
    }
}
