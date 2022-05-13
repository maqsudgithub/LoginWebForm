using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginWebForm.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required*")]
        public int DepID { get; set; }

        [Required(ErrorMessage = "Required*")]
        public int DesID { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Required*")]
        public string FName { get; set; }


        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required*")]
        public string Contact { get; set; }



        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string? Image { get; set; }

        [NotMapped]
        public string Department { get; set; }

        [NotMapped]
        public string Designation { get; set; }
    }
}
