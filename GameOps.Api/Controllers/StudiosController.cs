using GameOps.Application.Studios.CreateStudio;
using GameOps.Application.Studios.DeleteStudio;
using GameOps.Application.Studios.GetStudios;
using GameOps.Application.Studios.RenameStudio;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GameOps.Api.Controllers
{
    [ApiController]
    [Route("api/studios")]
    public class StudiosController : ControllerBase
    {
        private readonly CreateStudioHandler _createHandler;
        private readonly DeleteStudioHandler _deleteHandler;
        private readonly GetStudiosHandler _getHandler;
        private readonly UpdateStudioHandler _updateHandler;

        public StudiosController(CreateStudioHandler createHandler, 
            DeleteStudioHandler deleteHandler,
            GetStudiosHandler getHandler,
            UpdateStudioHandler renameHandler)
        {
            _createHandler = createHandler;
            _deleteHandler = deleteHandler;
            _getHandler = getHandler;
            _updateHandler = renameHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudioCommand command)
        {
            var id = await _createHandler.Handle(command);
            return CreatedAtAction(nameof(Create), new { id }, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studios = await _getHandler.GetAllAsync();
            return Ok(studios);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var studio = await _getHandler.GetByIdAsync(id);
            if (studio is null) return NotFound();
            return Ok(studio);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteHandler.Handle(new DeleteStudioCommand(id));
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStudioCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            await _updateHandler.Handle(command);
            return NoContent();
        }
    }
}
