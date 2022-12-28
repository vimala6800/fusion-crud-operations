using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.ProjectManagers.Commands;
using PartnerPortal.Application.SalesPersons.Commands;
using PartnerPortal.Application.TodoItems.Commands;
using PartnerPortal.Application.TodoLists.Commands;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{
    
    public class ProjectManagersController : ApiControllerBase
    {
        private readonly ApplicationDbContext _fullStackDbContext;
        public ProjectManagersController(ApplicationDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllPartners()
        {
            var partners = await _fullStackDbContext.ProjectManagers.ToListAsync();
            return Ok(partners);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProjectManagerCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateDetails(Guid id, UpdateProjectManagerDetailsCommand command)
        {
            if (id != command.ProjectManagerID)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteProjectManagerCommand(id));

            return NoContent();
        }
    }
}
