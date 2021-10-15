using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class FamilyList:ComponentBase
    {
        private IList<Family> allFamilies;
        private IList<Family> toShowFamilies;
        
        protected override async Task OnInitializedAsync()
        {
            allFamilies = fileReader.GetAllFamilies();
            toShowFamilies = allFamilies;
        }

        public void NavigateToFamily(String StreetName, int HouseNumber)
        {
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
        
    }
}