using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Models
{
    public class Family
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
            Children = new List<Child>();
        }
    }
}