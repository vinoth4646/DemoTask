using System.ComponentModel.DataAnnotations;

namespace AmazonWebApplication.Models
{
    public class Brand
    {
        [Key]
        public Guid EmpId { get; set; }

        [Required]
        public string EmpName { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }

       

    }
}
