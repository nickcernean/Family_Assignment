using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Family_Assignment.Pages
{
    public partial class AddInterest:ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
        [Parameter] public int IdOfChild { get; set; }
        
        private Interest interestToAdd;
        private Family family;
        
        protected override async Task OnInitializedAsync()
        {
            interestToAdd = new Interest();
            family = fileReader.GetFamily(StreetName, HouseNumber);
        }

        private void AddNewInterest()
        {
            family.Children.Find(t => t.Id == IdOfChild).Interests.Add(interestToAdd);
            fileReader.UpdateFamily(family);
            NavMgr.NavigateTo($"ChildView/{StreetName}/{HouseNumber}/{IdOfChild}");
        }
    }
}