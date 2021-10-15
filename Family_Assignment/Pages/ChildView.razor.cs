﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class ChildView:ComponentBase 
    {
        [Parameter]
        public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
        
        private Child childToView { get; set; }
        private IList<Pet> childsPets { get; set; }
        private IList<Interest> childsInterests { get; set; }

        private Family updateFamily;


        
        protected override async Task OnInitializedAsync()
        {
            childToView = fileReader.GetFamily(StreetName,HouseNumber).Children.Find(t => t.Id == Id);
            childsPets = childToView.Pets;
            childsInterests = childToView.Interests;
            updateFamily = fileReader.GetFamily(StreetName, HouseNumber);
        }

        public void DeletePet(int id)
        {
            updateFamily.Children.First(x => x.Id == Id).Pets.Remove(childsPets.First(t => t.Id == id));
            fileReader.UpdateFamily(updateFamily);
        }

        public void DeleteInterests(Interest interest)
        {
            updateFamily.Children.First(x => x.Id == Id).Interests.Remove(interest);
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