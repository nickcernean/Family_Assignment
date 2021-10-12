using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Protocol;
using Models;

namespace Family_Assignment.Data
{
    public interface IFamilyReader
    {
        IList<Family> GetAllFamilies();
        void AddFamily(Family family);
        void RemoveFamily(Family family);
        void UpdateFamily(Family family);
         Family GetFamily(string streetName, int streetNumber);
        
    }
}