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
    public partial class FamilyList : ComponentBase
    {
        private IList<Family> allFamilies;
        private IList<Family> toShowFamilies;

        protected override async Task OnInitializedAsync()
        {
            allFamilies = await fileReader.GetAllFamiliesAsync();
            toShowFamilies = allFamilies;
        }

        public void NavigateToFamily(String StreetName, int HouseNumber)
        {
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
    }
}