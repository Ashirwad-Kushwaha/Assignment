using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class todolist
    {
        public int Id { get; set; }

        [Required]
        public string Task { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
