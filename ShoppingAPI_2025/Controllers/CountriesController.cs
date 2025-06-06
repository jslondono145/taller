using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_2025.DAL.Entities;
using ShoppingAPI_2025.Domain.Interfaces;

namespace ShoppingAPI_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        
        public CountriesController (ICountryService countryService)
        {
            _countryService = countryService;
        }
        
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountriesAsync()
        {
            var countryEntities = await _countryService.GetAllCountriesAsync();

            if (countryEntities == null || !countryEntities.Any()) return NotFound();

            return Ok(countryEntities);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{countryId}")]
        public async Task<ActionResult<Country>> GetCountryByIdentifierAsync(Guid countryId)
        {
            var countryEntity = await _countryService.GetCountryByIdentifierAsync(countryId);

            if (countryEntity == null) return NotFound();

            return Ok(countryEntity);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateNewCountryAsync(Country countryEntity)
        {
            try
            {
                var newCountryEntity = await _countryService.CreateNewCountryAsync(countryEntity);
                if (newCountryEntity == null) return NotFound();
                return Ok(newCountryEntity);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} already exists", countryEntity.CountryName));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> UpdateCountryAsync(Country countryEntity)
        {
            try
            {
                var updatedCountryEntity = await _countryService.UpdateCountryAsync(countryEntity);
                if (updatedCountryEntity == null) return NotFound();
                return Ok(updatedCountryEntity);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} already exists", countryEntity.CountryName));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> RemoveCountryAsync(Guid countryId)
        {
            if (countryId == Guid.Empty) return BadRequest();

            var removedCountryEntity = await _countryService.RemoveCountryAsync(countryId);

            if (removedCountryEntity == null) return NotFound();

            return Ok(removedCountryEntity);
        }
    }
}
