using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class FamilyView:ComponentBase
    {
        [Parameter]
        public string StreetName { get; set; }
        [Parameter]
        public int HouseNumber { get; set; }

        private IList<Adult> allAdults;
        private IList<Adult> toShowAdults;
        
        protected override async Task OnInitializedAsync()
        {
            allAdults = fileReader.GetFamily(StreetName,HouseNumber).Adults;
            toShowAdults = allAdults;
        }
    }
}