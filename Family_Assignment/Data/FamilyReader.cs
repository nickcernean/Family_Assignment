using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Models;

namespace Family_Assignment.Data
{
    public class FamilyReader : IFamilyReader
    {

        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;


        public FamilyReader()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            client = new HttpClient(clientHandler);
        }
        
        // public Task<IList<Family>> GetAllFamiliesAsync()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public Task<Family> AddFamilyAsync(Family family)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public Task RemoveFamilyAsync(Family family)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public Task<Family> UpdateFamilyAsync(Family family)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        // {
        //     throw new System.NotImplementedException();
        // }
        public IList<Family> GetAllFamilies()
        {
            throw new System.NotImplementedException();
        }

        public void AddFamily(Family family)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFamily(Family family)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateFamily(Family family)
        {
            throw new System.NotImplementedException();
        }

        public Family GetFamily(string streetName, int houseNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}