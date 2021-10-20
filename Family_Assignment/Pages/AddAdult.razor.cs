using System.Collections;
using System.Threading.Tasks;
using Family_Assignment.Data;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class AddAdult : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Adult adultToAdd;
        private Job adultsJob;
        private IList allAdults;

        protected override async Task OnInitializedAsync()
        {
            adultToAdd = new Adult();
            adultsJob = new Job {JobTitle = "no job", Salary = 0};
            allAdults = fileReader.GetFamilyAsync(StreetName, HouseNumber).Result.Adults;
        }

        private async Task AddNewAdult()
        {
            adultToAdd.JobTitle = adultsJob;
            adultToAdd.Id = getNewId();
            Family forUpdate = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            forUpdate.Adults.Add(adultToAdd);
            await fileReader.UpdateFamilyAsync(forUpdate);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }

        private int getNewId()
        {
            int result = allAdults.Count + 1;
            int check = 1;
            foreach (Adult x in allAdults)
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