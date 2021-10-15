using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class EditAdult:ComponentBase
    {
        [Parameter]
        public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
        
        private Adult adultToEdit;
        private Family familyToEdit;
        
        protected override async Task OnInitializedAsync()
        {
            familyToEdit = fileReader.GetFamily(StreetName, HouseNumber);
            adultToEdit = familyToEdit.Adults.Find(t => t.Id == Id);
        }

        private void Update()
        {
            Adult update = familyToEdit.Adults.Find(t => t.Id == Id);
            update = adultToEdit;
            fileReader.UpdateFamily(familyToEdit);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
    }
}