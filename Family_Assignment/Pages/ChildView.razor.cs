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
        [Parameter] public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Child childToView { get; set; }
        private List<Pet> childsPets { get; set; }
        private List<Interest> childsInterests { get; set; }

        private Family updateFamily;


        protected override async Task OnInitializedAsync()
        {
            updateFamily = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            childToView = updateFamily.Children.Find(t => t.Id == Id);
            childsPets = childToView.Pets;
            childsInterests = childToView.Interests;
        }

        public async Task DeletePet(Pet pet)
        {
            
            updateFamily.Children.Find(x => x.Id == Id).Pets.Remove(pet);
            await fileReader.UpdateFamilyAsync(updateFamily);
        }

        public async Task DeleteInterests(Interest interest)
        {
            updateFamily.Children.First(x => x.Id == Id).Interests.Remove(interest);
            await fileReader.UpdateFamilyAsync(updateFamily);
        }

        public void NavigateToAddPet()
        {
            NavMgr.NavigateTo($"AddPet/{StreetName}/{HouseNumber}/{Id}");
        }

        public void NavigateToAddInterest()
        {
            NavMgr.NavigateTo($"AddInterest/{StreetName}/{HouseNumber}/{Id}");
        }
    }
}