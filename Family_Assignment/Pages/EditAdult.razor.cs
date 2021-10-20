using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class EditAdult : ComponentBase
    {
        [Parameter] public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Adult adultToEdit;
        private Family familyToEdit;

        protected override async Task OnInitializedAsync()
        {
            familyToEdit = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            adultToEdit = familyToEdit.Adults.Find(t => t.Id == Id);
        }

        private async Task Update()
        {
            Adult update = familyToEdit.Adults.Find(t => t.Id == Id);
            update = adultToEdit;
            await fileReader.UpdateFamilyAsync(familyToEdit);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
    }
}