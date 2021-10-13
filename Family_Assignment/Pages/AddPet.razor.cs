using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class AddPet:ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
        [Parameter] public int IdOfChild { get; set; }
        
        private Pet petToAdd;
        private Family family;
        
        protected override async Task OnInitializedAsync()
        {
            petToAdd = new Pet();
            family = fileReader.GetFamily(StreetName, HouseNumber);
        }

        private void AddNewPetToChild()
        {
            
            family.Children.Find(t => t.Id == IdOfChild).Pets.Add(petToAdd);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
        private void AddNewPetToFamily()
        {
            family = fileReader.GetFamily(StreetName, HouseNumber);
            family.Pets.Add(petToAdd);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
    }
}