using GameOps.Application.Studios.CreateStudio;
using Microsoft.AspNetCore.Mvc;

namespace GameOps.Api.Controllers
{
    [ApiController]
    [Route("api/studios")]
    public class StudiosController : ControllerBase
    {
        private readonly CreateStudioHandler _handler;

        public StudiosController(CreateStudioHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudioCommand command)
        {
            var id = await _handler.Handle(command);
            return CreatedAtAction(nameof(Create), new { id }, null);
        }
    }
}
