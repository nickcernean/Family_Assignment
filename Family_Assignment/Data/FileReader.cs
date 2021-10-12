using System.Collections.Generic;
using System.Linq;
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

        public IList<Family> GetAllFamilies()
        {
            return FileContext.Families;
        }

        public void AddFamily(Family family)
        {
            FileContext.Families.Add(family);
            FileContext.SaveChanges();
        }

        public void RemoveFamily(Family family)
        {
            FileContext.Families.Remove(family);
            FileContext.SaveChanges();
        }

        public void UpdateFamily(Family family)
        {
            FileContext.Families.Remove(family);
            FileContext.SaveChanges();
        }

        public Family GetFamily(string streetName, int houseNumber)
        {
            return GetAllFamilies().FirstOrDefault(family =>
                family.StreetName.Equals(streetName) && family.HouseNumber.Equals(houseNumber));
        }
    }
}