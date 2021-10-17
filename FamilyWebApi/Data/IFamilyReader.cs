using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Protocol;
using Models;

namespace Family_Assignment.Data
{
    public interface IFamilyReader
    {
        Task<IList<Family>> GetAllFamiliesAsync();
        Task AddFamilyAsync(Family family);
        Task RemoveFamilyAsync(Family family);
        Task<Family> UpdateFamilyAsync(Family family);
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
    }
}