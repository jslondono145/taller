using ShoppingAPI_2025.DAL.Entities;

namespace ShoppingAPI_2025.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryByIdentifierAsync(Guid countryId);
        Task<Country> CreateNewCountryAsync(Country countryEntity);
        Task<Country> UpdateCountryAsync(Country countryEntity);
        Task<Country> RemoveCountryAsync(Guid countryId);
    }
}
