using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Family_Assignment.Data;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class AddPet : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
        [Parameter] public int IdOfChild { get; set; }

        private Pet petToAdd;
        private Family family;
        private IList<Pet> listOfPets;

        protected override async Task OnInitializedAsync()
        {
            petToAdd = new Pet();
            family = fileReader.GetFamily(StreetName, HouseNumber);
            listOfPets = family.Pets;
        }

        private void AddNewPetToChild()
        {
            family.Children.Find(t => t.Id == IdOfChild).Pets.Add(petToAdd);
            fileReader.UpdateFamily(family);
            NavMgr.NavigateTo($"ChildView/{StreetName}/{HouseNumber}/{IdOfChild}");
        }

        private void AddNewPetToFamily()
        {
            petToAdd.Id = getNewId();
            family = fileReader.GetFamily(StreetName, HouseNumber);
            family.Pets.Add(petToAdd);
            fileReader.UpdateFamily(family);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }

        private int getNewId()
        {
            int result = listOfPets.Count + 1;
            int check = 1;
            foreach (Pet x in listOfPets)
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