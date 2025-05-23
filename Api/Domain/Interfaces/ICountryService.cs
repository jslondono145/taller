using Api.DAL.Entities;

namespace Api.Domain.Interfaces
{
    public interface ICountryService
    {
        
        Task<IEnumerable<Country>> GetCountriesAsync(); 

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);
    }
}
