using System.Collections;
using System.Collections.Generic;
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
        private IList<Child> allChildren;

        protected override async Task OnInitializedAsync()
        {
            childToAdd = new Child();
            allChildren = fileReader.GetFamily(StreetName, HouseNumber).Children;

        }

        private void AddNewChild()
        {
            childToAdd.Interests = new List<Interest>();
            childToAdd.Pets = new List<Pet>();
            childToAdd.Id = getNewId();
            Family forUpdate = fileReader.GetFamily(StreetName, HouseNumber);
            forUpdate.Children.Add(childToAdd);
            fileReader.UpdateFamily(forUpdate);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }

        private int getNewId()
        {
            int result = allChildren.Count + 1;
            int check = 1;
            foreach (Child x in allChildren)
            {
                if (check == x.Id)
                {
                    check++;
                }
                else
                {
                    result = check;
                    check++;
                }
            }

            return result;
        }
    }
}