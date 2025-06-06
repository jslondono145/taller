using Microsoft.EntityFrameworkCore;
using ShoppingAPI_2025.DAL;
using ShoppingAPI_2025.DAL.Entities;
using ShoppingAPI_2025.Domain.Interfaces;

namespace ShoppingAPI_2025.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _databaseContext;
        
        public CountryService(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            try
            {
                var countryEntities = await _databaseContext.Countries.ToListAsync();
                return countryEntities;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdentifierAsync(Guid countryId)
        {
            try
            {
                var countryEntity = await _databaseContext.Countries.FirstOrDefaultAsync(country => country.EntityId == countryId);
                return countryEntity;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> CreateNewCountryAsync(Country countryEntity)
        {
            try
            {
                countryEntity.EntityId = Guid.NewGuid();
                countryEntity.CreationDate = DateTime.Now;
                _databaseContext.Countries.Add(countryEntity);

                await _databaseContext.SaveChangesAsync();

                return countryEntity;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? 
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> UpdateCountryAsync(Country countryEntity)
        {
            try
            {
                countryEntity.LastModificationDate = DateTime.Now;
                _databaseContext.Countries.Update(countryEntity);
                await _databaseContext.SaveChangesAsync();
                return countryEntity;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> RemoveCountryAsync(Guid countryId)
        {
            try
            {
                var countryEntity = await GetCountryByIdentifierAsync(countryId);
                if (countryEntity == null)
                {
                    return null;
                }
                _databaseContext.Countries.Remove(countryEntity);
                await _databaseContext.SaveChangesAsync();

                return countryEntity;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
    }
}
