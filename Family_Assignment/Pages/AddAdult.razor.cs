using System.Threading.Tasks;
using Family_Assignment.Data;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class AddAdult:ComponentBase
    {
        
        [Parameter]
        public string StreetName { get; set; }
        [Parameter]
        public int HouseNumber { get; set; }
        
        private Adult adultToAdd;
        private Job adultsJob;
        
        protected override async Task OnInitializedAsync()
        {
            adultToAdd = new Adult();
            adultsJob = new Job {JobTitle = "no job", Salary = 0};
        }
        private void AddNewAdult()
        {

            adultToAdd.JobTitle = adultsJob;
            adultToAdd.Id = getNewId();
            Family forUpdate = fileReader.GetFamily(StreetName,HouseNumber);
            forUpdate.Adults.Add(adultToAdd);
            fileReader.UpdateFamily(forUpdate);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }

        private int getNewId()
        {
            int result = 0;
            foreach (Adult x in fileReader.GetFamily(StreetName,HouseNumber).Adults)
            {
                result = x.Id + 1;
            }
            return result;
        }
    }
}