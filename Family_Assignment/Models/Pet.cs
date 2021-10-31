using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Models
{
    public class Pet
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}