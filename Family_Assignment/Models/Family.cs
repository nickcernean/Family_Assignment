using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Models
{
    public class Family
    {
        [Required] public string StreetName { get; set; }
        [Required,Range(1, int.MaxValue, ErrorMessage = "Please enter house number")] public int HouseNumber { get; set; }

        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }
    }
}