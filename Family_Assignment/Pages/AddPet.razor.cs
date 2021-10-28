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
        private IList<Pet> listOfPetsFamily;
        private IList<Pet> listOfPetsChild;
        protected override async Task OnInitializedAsync()
        {
            petToAdd = new Pet();
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            listOfPetsFamily = family.Pets;
            listOfPetsChild = family.Children.Find(t => t.Id == IdOfChild).Pets;
        }

        private async Task AddNewPetToChild()
        {//edit it 
            petToAdd.Id = GetNewId();
            family.Children.Find(t => t.Id == IdOfChild).Pets.Add(petToAdd);
            await fileReader.UpdateFamilyAsync(family);
            NavMgr.NavigateTo($"ChildView/{StreetName}/{HouseNumber}/{IdOfChild}");
        }

        private async Task AddNewPetToFamily()
        {
            petToAdd.Id = GetNewId();
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            family.Pets.Add(petToAdd);
            await fileReader.UpdateFamilyAsync(family);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }

        private int GetNewId()
        {
            IList<Pet> list;
            if (IdOfChild == 0)
            {
                list = listOfPetsFamily;
            }
            else
            {
                list = listOfPetsChild;
            }
            int result = list.Count + 1;
            int check = 1;
            foreach (Pet x in list)
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