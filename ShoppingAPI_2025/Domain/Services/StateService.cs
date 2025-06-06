using Microsoft.EntityFrameworkCore;
using ShoppingAPI_2025.DAL;
using ShoppingAPI_2025.DAL.Entities;
using ShoppingAPI_2025.Domain.Interfaces;

namespace ShoppingAPI_2025.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _databaseContext;

        public StateService(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            try
            {
                var stateEntities = await _databaseContext.States
                    .Include(stateEntity => stateEntity.AssociatedCountry)
                    .ToListAsync();
                return stateEntities;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<State> GetStateByIdentifierAsync(Guid stateId)
        {
            try
            {
                var stateEntity = await _databaseContext.States
                    .Include(stateEntity => stateEntity.AssociatedCountry)
                    .FirstOrDefaultAsync(stateEntity => stateEntity.EntityId == stateId);
                return stateEntity;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<State> CreateNewStateAsync(State stateEntity)
        {
            try
            {
                stateEntity.EntityId = Guid.NewGuid();
                stateEntity.CreationDate = DateTime.Now;
                _databaseContext.States.Add(stateEntity);
                await _databaseContext.SaveChangesAsync();
                return stateEntity;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<State> UpdateStateAsync(State stateEntity)
        {
            try
            {
                stateEntity.LastModificationDate = DateTime.Now;
                _databaseContext.States.Update(stateEntity);
                await _databaseContext.SaveChangesAsync();
                return stateEntity;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<State> RemoveStateAsync(Guid stateId)
        {
            try
            {
                var stateEntity = await GetStateByIdentifierAsync(stateId);
                if (stateEntity == null)
                {
                    return null;
                }
                _databaseContext.States.Remove(stateEntity);
                await _databaseContext.SaveChangesAsync();
                return stateEntity;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
    }
}
