using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace ReactCrudApp.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string stname { get; set; }
        public string course { get; set; }
    }
}
