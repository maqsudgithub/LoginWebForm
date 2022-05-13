using System.ComponentModel.DataAnnotations;

namespace LoginWebForm.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Required*")]
        public string Name { get; set; }
    }
}
