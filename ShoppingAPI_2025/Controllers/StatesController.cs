using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_2025.DAL.Entities;
using ShoppingAPI_2025.Domain.Interfaces;

namespace ShoppingAPI_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<State>>> GetAllStatesAsync()
        {
            var stateEntities = await _stateService.GetAllStatesAsync();

            if (stateEntities == null || !stateEntities.Any()) return NotFound();

            return Ok(stateEntities);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{stateId}")]
        public async Task<ActionResult<State>> GetStateByIdentifierAsync(Guid stateId)
        {
            var stateEntity = await _stateService.GetStateByIdentifierAsync(stateId);

            if (stateEntity == null) return NotFound();

            return Ok(stateEntity);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<State>> CreateNewStateAsync(State stateEntity)
        {
            try
            {
                var newStateEntity = await _stateService.CreateNewStateAsync(stateEntity);
                if (newStateEntity == null) return NotFound();
                return Ok(newStateEntity);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} already exists", stateEntity.StateName));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<State>> UpdateStateAsync(State stateEntity)
        {
            try
            {
                var updatedStateEntity = await _stateService.UpdateStateAsync(stateEntity);
                if (updatedStateEntity == null) return NotFound();
                return Ok(updatedStateEntity);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} already exists", stateEntity.StateName));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> RemoveStateAsync(Guid stateId)
        {
            if (stateId == Guid.Empty) return BadRequest();

            var removedStateEntity = await _stateService.RemoveStateAsync(stateId);

            if (removedStateEntity == null) return NotFound();

            return Ok(removedStateEntity);
        }
    }
}

