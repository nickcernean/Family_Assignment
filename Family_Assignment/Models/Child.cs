using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Models
{
    public class Child :Person
    {
        public List<Interest> Interests { get; set; }
        public List<Pet> Pets { get; set; }

    }
}