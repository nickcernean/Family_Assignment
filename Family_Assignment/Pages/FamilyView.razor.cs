using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public Family updateFamily;
        
        protected override async Task OnInitializedAsync()
        {
            updateFamily = fileReader.GetFamily(StreetName, HouseNumber);
            allAdults = fileReader.GetFamily(StreetName,HouseNumber).Adults;
            allChildren = fileReader.GetFamily(StreetName,HouseNumber).Children;
            allPets = fileReader.GetFamily(StreetName,HouseNumber).Pets;
            toShowAdults = allAdults;
            toShowChildren = allChildren;
            toShowPets = allPets;
        }

        public void DeleteAdult(int Id)
        {
            updateFamily.Adults.Remove(allAdults.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
        }
        public void DeleteChildren(int Id)
        {
            updateFamily.Children.Remove(allChildren.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
        }
        public void DeletePet(int Id)
        {
            updateFamily.Pets.Remove(allPets.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
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
    }
}