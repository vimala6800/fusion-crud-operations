using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Dummy.Commands;
using PartnerPortal.Application.TodoItems.Commands;
using PartnerPortal.Application.TodoLists.Commands;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{
    public class RequisitionFilesController : ApiControllerBase
    {

        private readonly ApplicationDbContext _fullStackDbContext;
        public RequisitionFilesController(ApplicationDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllPartners()
        {
            var partners = await _fullStackDbContext.RequisitionFiles.ToListAsync();
            return Ok(partners);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequisitionFilesCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateDetails(Guid id, UpdateRequisitionFilesDetailsCommand command)
        {
            if (id != command.RequisitionFileID)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteRequisitionFilesCommand(id));

            return NoContent();
        }
    }
}
