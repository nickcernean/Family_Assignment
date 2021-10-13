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
        private IList<Child> allChildren;
        private IList<Pet> allPets;
        private IList<Adult> toShowAdults;
        private IList<Child> toShowChildren;
        private IList<Pet> toShowPets;
        
        protected override async Task OnInitializedAsync()
        {
            allAdults = fileReader.GetFamily(StreetName,HouseNumber).Adults;
            allChildren = fileReader.GetFamily(StreetName,HouseNumber).Children;
            allPets = fileReader.GetFamily(StreetName,HouseNumber).Pets;
            toShowAdults = allAdults;
            toShowChildren = allChildren;
            toShowPets = allPets;
        }

        public void NavigateToAddAdult()
        {
            NavMgr.NavigateTo($"AddAdult/{StreetName}/{HouseNumber}");
        }
        public void NavigateToAddChildren()
        {
            NavMgr.NavigateTo($"AddChildren/{StreetName}/{HouseNumber}");
        }
        public void NavigateToAddPet()
        {
            NavMgr.NavigateTo($"AddPet/{StreetName}/{HouseNumber}/{0}");
        }

        public void NavigateToAdultView(int id)
        {
            NavMgr.NavigateTo($"AdultView/{StreetName}/{HouseNumber}/{id}");
        }
        
        public void NavigateToChildView(int id)
        {
            NavMgr.NavigateTo($"ChildView/{StreetName}/{HouseNumber}/{id}");
        }
        
        public void NavigateToPetView(int id)
        {
            NavMgr.NavigateTo($"PetView/{StreetName}/{HouseNumber}/{id}");
        }
    }
}