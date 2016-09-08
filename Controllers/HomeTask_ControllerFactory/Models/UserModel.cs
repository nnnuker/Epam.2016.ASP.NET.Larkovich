using System.ComponentModel.DataAnnotations;

namespace HomeTask_ControllerFactory.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
    }
}