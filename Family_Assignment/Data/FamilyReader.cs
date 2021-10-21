using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

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

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            List<Family> families = new List<Family>();
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Family");
            String reply = await responseMessage.Content.ReadAsStringAsync();
            // Task<string> families = client.GetStringAsync(uri + "/Adult");
            // string message = await families;
            // IList<Family> result = JsonConvert.DeserializeObject<List<Family>>(message);
            families = JsonConvert.DeserializeObject<List<Family>>(reply);
            return families;
        }

        public async Task<HttpStatusCode> AddFamilyAsync(Family family)
        {
            string serializedFamily = JsonConvert.SerializeObject(family);
            StringContent content = new StringContent(serializedFamily, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Family/newFamily", content);

            return responseMessage.StatusCode;
        }

        public async Task<HttpStatusCode> RemoveFamilyAsync(Family family)
        {
            HttpResponseMessage responseMessage =
                await client.DeleteAsync($"{uri}/Family/{family.StreetName}/{family.HouseNumber}");
            return responseMessage.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateFamilyAsync(Family family)
        {
            try
            {
                string serializedFamily = JsonConvert.SerializeObject(family);
                Console.WriteLine("1st"+family.Adults[0].FirstName);
                Console.WriteLine("2nd"+family.Adults[1].FirstName);

                StringContent content = new StringContent(serializedFamily, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage =
                    await client.PatchAsync($"{uri}/Family/{family.StreetName}/{family.HouseNumber}", content);
                return responseMessage.StatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/Family/{streetName}/{houseNumber}");
            String reply = await responseMessage.Content.ReadAsStringAsync();
            Family family = JsonConvert.DeserializeObject<Family>(reply);
            return family;
        }

        // public IList<Family> GetAllFamilies()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public void AddFamily(Family family)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public void RemoveFamily(Family family)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public void UpdateFamily(Family family)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public Family GetFamily(string streetName, int houseNumber)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}