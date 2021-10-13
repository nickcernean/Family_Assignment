using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class AddChildren : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Child childToAdd;
        private Interest childsInterests;
        private Pet childPets;

        protected override async Task OnInitializedAsync()
        {
            childToAdd = new Child();
            //childsInterests = new Interest{Type = "no interes", Description = null};
        }

        private void AddNewChild()
        {
            childToAdd.Interests = null;
            childToAdd.Pets = null;
            childToAdd.Id = getNewId();
            Family forUpdate = fileReader.GetFamily(StreetName, HouseNumber);
            forUpdate.Children.Add(childToAdd);
            fileReader.UpdateFamily(forUpdate);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }

        private int getNewId()
        {
            int result = 0;
            foreach (Adult x in fileReader.GetFamily(StreetName, HouseNumber).Adults)
            {
                result = x.Id + 1;
            }

            return result;
        }
    }
}