using Microsoft.AspNetCore.Components;

namespace Family_Assignment.Pages
{
    public partial class AdultView:ComponentBase
    {
        [Parameter]
        public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
    }
}