using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Family_Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private IFamilyReader familyReader;

        public FamilyController(IFamilyReader familyReader)
        {
            this.familyReader = familyReader;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetAllFamilies()
        {
            try
            {
                IList<Family> families = await familyReader.GetAllFamiliesAsync();
                string familiesAsJson = JsonSerializer.Serialize(families);
                return Ok(familiesAsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFamily([FromBody] Family family)
        {
            try
            {
                await familyReader.RemoveFamilyAsync(family);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
        {
            
            try
            {
                Family familyAdded = await familyReader.AddFamilyAsync(family);
                return Created($"/{familyAdded.StreetName} / {familyAdded.HouseNumber}", familyAdded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

      [HttpPatch]
      // [Route("{streetName:regex}/{streetNumber}")]
        public async Task<ActionResult<Family>> Updatefamily([FromBody] Family family)
        {
            try
            {
                Family updatedFamily = await familyReader.UpdateFamilyAsync(family);
                return Ok(updatedFamily);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}