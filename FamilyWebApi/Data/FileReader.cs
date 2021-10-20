using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Family_Assignment.Data
{
    public class FileReader : IFamilyReader
    {
        private FileContext FileContext;

        public FileReader()
        {
            FileContext = new FileContext();
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            return FileContext.Families;
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            FileContext.Families.Add(family);
            FileContext.SaveChanges();
            return family;
        }

        public async Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            Family family = await GetFamilyAsync(streetName, houseNumber);
            FileContext.Families.Remove(family);
            FileContext.SaveChanges();
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            Family familyToUpdate = GetAllFamiliesAsync().Result.First(t =>
                t.StreetName.Equals(family.StreetName) && t.HouseNumber == family.HouseNumber);
            familyToUpdate = family;
            FileContext.SaveChanges();
            return familyToUpdate;
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
            return GetAllFamiliesAsync().Result.FirstOrDefault(family =>
                family.StreetName.Equals(streetName) && family.HouseNumber.Equals(houseNumber));
        }
    }
}