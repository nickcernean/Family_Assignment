using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class AdultView:ComponentBase
    {
        [Parameter]
        public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Adult adultToView;
        private Job jobToView;
        private Job newJob;
        
        protected override async Task OnInitializedAsync()
        {
            adultToView = fileReader.GetFamily(StreetName,HouseNumber).Adults.Find(t => t.Id == Id);
            newJob = new Job();
            jobToView = adultToView.JobTitle;
        }

        public void AddJob()
        {
            jobToView = newJob;
            Family theFamily = fileReader.GetFamily(StreetName, HouseNumber);
            theFamily.Adults.Find(t => t.Id == Id).JobTitle = newJob;
            fileReader.UpdateFamily(theFamily);
        }
        
        public void DeleteJob()
        {
            Family theFamily = fileReader.GetFamily(StreetName, HouseNumber);
            theFamily.Adults.Find(t => t.Id == Id).JobTitle = new Job();
            fileReader.UpdateFamily(theFamily);
        }
    }
}