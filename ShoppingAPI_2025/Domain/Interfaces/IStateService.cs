using ShoppingAPI_2025.DAL.Entities;

namespace ShoppingAPI_2025.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetAllStatesAsync();
        Task<State> GetStateByIdentifierAsync(Guid stateId);
        Task<State> CreateNewStateAsync(State stateEntity);
        Task<State> UpdateStateAsync(State stateEntity);
        Task<State> RemoveStateAsync(Guid stateId);
    }
}
