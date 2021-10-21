using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace FamilyWebApi.Data
{
    public class FileReader : IFamilyReader
    {
        private FileContext FileContext;
        private IList<Family> families;

        public FileReader()
        {
            FileContext = new FileContext();
            families = FileContext.Families;
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            return families;
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            families.Add(family);
            FileContext.SaveChanges();
            return family;
        }

        public async Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            Family family =
                families.FirstOrDefault(
                    t => t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber);
            families.Remove(family);
            FileContext.SaveChanges();
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            Console.WriteLine("UpdateFamilyAsync got" + family.Adults[0].FirstName);
            Console.WriteLine("UpdateFamilyAsync got" + family.Adults[1].FirstName);
            
            Family familyToUpdate = families.FirstOrDefault(t =>
                t.StreetName.Equals(family.StreetName) && t.HouseNumber == family.HouseNumber);
            
            Console.WriteLine("UpdateFamilyAsync familyToUpdate" + familyToUpdate.Adults[0].FirstName);
            Console.WriteLine("UpdateFamilyAsync familyToUpdate" + familyToUpdate.Adults[1].FirstName);
            familyToUpdate = family;
            Console.WriteLine("UpdateFamilyAsync familyToUpdate01" + familyToUpdate.Adults[0].FirstName);
            Console.WriteLine("UpdateFamilyAsync familyToUpdate01" + familyToUpdate.Adults[1].FirstName);
            
            
            FileContext.SaveChanges();
            return familyToUpdate;
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
            return families.FirstOrDefault(family =>
                family.StreetName.Equals(streetName) && family.HouseNumber.Equals(houseNumber));
        }
    }
}