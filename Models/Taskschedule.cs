using System.ComponentModel.DataAnnotations;

namespace Taskscheduler.Models
{
    public class Taskschedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
