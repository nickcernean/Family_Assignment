using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class EditAdult : ComponentBase
    {
        [Parameter] public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Adult adultToEdit;
        private Family familyToEdit;

        protected override async Task OnInitializedAsync()
        {
            familyToEdit = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            adultToEdit = familyToEdit.Adults.Find(t => t.Id == Id);
        }

        private async Task Update()
        {
            Adult updateAdult = familyToEdit.Adults.Find(t => t.Id == adultToEdit.Id);
            updateAdult = adultToEdit;
           HttpStatusCode reponse= await fileReader.UpdateFamilyAsync(familyToEdit);
           
           Console.WriteLine(reponse == HttpStatusCode.OK);
          Console.WriteLine(reponse == HttpStatusCode.InternalServerError);

            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
    }
}