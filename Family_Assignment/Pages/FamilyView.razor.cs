using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging.Abstractions;
using Models;

namespace Family_Assignment.Pages
{
    public partial class FamilyView : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private IList<Adult> allAdults;
        private IList<Child> allChildren;
        private IList<Pet> allPets;
        private IList<Adult> toShowAdults;
        private IList<Child> toShowChildren;
        private IList<Pet> toShowPets;

        private string filterById;
        private string filterByFirstName;
        private string filterByLastName;
        private string filterByAge;

        private int? filterByIdArg;
        private string? filterByFirstNameArg;
        private string? filterByLastNameArg;
        private int? filterByAgeArg;

        public Family updateFamily;

        protected override async Task OnInitializedAsync()
        {
            updateFamily = fileReader.GetFamily(StreetName, HouseNumber);
            allAdults = fileReader.GetFamily(StreetName, HouseNumber).Adults;
            allChildren = fileReader.GetFamily(StreetName, HouseNumber).Children;
            allPets = fileReader.GetFamily(StreetName, HouseNumber).Pets;
            toShowAdults = allAdults;
            toShowChildren = allChildren;
            toShowPets = allPets;
        }

        private void FilterByType(ChangeEventArgs eventArgs)
        {
            filterById = null;
            filterByFirstName = null;
            filterByLastName = null;
            filterByAge = null;
            try
            {
                string value = eventArgs.Value.ToString();
                switch (value)
                {
                    case "Id":
                        filterById = value;
                        break;
                    case "FirstName":
                        filterByFirstName = value;
                        break;
                    case "LastName":
                        filterByLastName = value;
                        break;
                    case "Age":
                        filterByAge = value;
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void FilterArg(ChangeEventArgs eventArgs)
        {
            filterByIdArg = null;
            filterByFirstNameArg = null;
            filterByLastNameArg = null;
            filterByAgeArg = null;
            try
            {
                // if (filterById != null)
                {
                    filterByIdArg =int.Parse(eventArgs.Value.ToString());
                }

                // if (filterByFirstName != null)
                {
                    //    filterByFirstNameArg = eventArgs.Value.ToString();
                }

                //  if (filterByLastName != null)
                {
                    //  filterByLastNameArg = eventArgs.Value.ToString();
                }

                // if (filterByAge != null)
                {
                    filterByAgeArg = int.Parse(eventArgs.Value.ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            ExecuteFilter();
        }

        private void ExecuteFilter()
        {
            toShowAdults = allAdults.Where(t =>
                    (filterByIdArg != null && t.Id == filterByIdArg || filterByIdArg == null))
                .ToList();
        }

        private void DeleteAdult(int Id)
        {
            updateFamily.Adults.Remove(allAdults.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
        }

        private void DeleteChildren(int Id)
        {
            updateFamily.Children.Remove(allChildren.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
        }

        private void DeletePet(int Id)
        {
            updateFamily.Pets.Remove(allPets.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
        }

        private void NavigateToAddAdult()
        {
            NavMgr.NavigateTo($"AddAdult/{StreetName}/{HouseNumber}");
        }

        private void NavigateToAddChildren()
        {
            NavMgr.NavigateTo($"AddChildren/{StreetName}/{HouseNumber}");
        }

        private void NavigateToAddPet()
        {
            NavMgr.NavigateTo($"AddPet/{StreetName}/{HouseNumber}/{0}");
        }

        private void NavigateToAdultView(int id)
        {
            NavMgr.NavigateTo($"AdultView/{StreetName}/{HouseNumber}/{id}");
        }

        private void NavigateToChildView(int id)
        {
            NavMgr.NavigateTo($"ChildView/{StreetName}/{HouseNumber}/{id}");
        }

        private void NavigateToEditAdult(int id)
        {
            NavMgr.NavigateTo($"EditAdult/{StreetName}/{HouseNumber}/{id}");
        }

        private void NavigateToEditChildren(int id)
        {
            NavMgr.NavigateTo($"EditChildren/{StreetName}/{HouseNumber}/{id}");
        }
    }
}