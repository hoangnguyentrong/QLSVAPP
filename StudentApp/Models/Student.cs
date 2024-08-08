using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Student()
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string? Code { get; set; }= string.Empty;
        [MaxLength(50)]
        public string Name { get; set; }= string.Empty;
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        [MaxLength(255)]
        public string Address { get; set; } =string.Empty;
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; } 
    }
}