using System.ComponentModel.DataAnnotations;

namespace web_api_curd.Model
{
    public class PersonModel
    {

        [Key]
        public int PersonID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
      
    }
}
