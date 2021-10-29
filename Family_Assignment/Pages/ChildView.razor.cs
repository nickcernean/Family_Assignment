using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;
using Newtonsoft.Json;

namespace Family_Assignment.Pages
{
    public partial class ChildView : ComponentBase
    {
        [Parameter] public int IdOfChild { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Child childToView { get; set; }

        private Family updateFamily;


        protected override async Task OnInitializedAsync()
        {
            updateFamily = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            childToView = updateFamily.Children.Find(t => t.Id == IdOfChild);
        }

        private async Task DeletePet(Pet pet)
        {
            
            updateFamily.Children.Find(x => x.Id == IdOfChild).Pets.Remove(pet);
            await fileReader.UpdateFamilyAsync(updateFamily);
        }

        private async Task DeleteInterests(Interest interest)
        {
            updateFamily.Children.First(x => x.Id == IdOfChild).Interests.Remove(interest);
            await fileReader.UpdateFamilyAsync(updateFamily);
        }

        private void NavigateToAddPet()
        {
            NavMgr.NavigateTo($"AddPet/{StreetName}/{HouseNumber}/{IdOfChild}");
        }

        private void NavigateToAddInterest()
        {
            NavMgr.NavigateTo($"AddInterest/{StreetName}/{HouseNumber}/{IdOfChild}");
        }
    }
}