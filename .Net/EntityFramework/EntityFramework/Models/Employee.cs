using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Column("first_name", TypeName="varchar(20)")]
        public string FirstName { get; set; }

        
        [Column("last_name", TypeName = "varchar(20)")]
        public string LastName { get; set; }

        
        [Column("age", TypeName = "int")]
        public int Age { get; set; }

        
        [Column("department")]
        public string Department { get; set; }
    }
}
