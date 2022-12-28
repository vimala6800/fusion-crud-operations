using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Application.SalesPersons.Commands;
using PartnerPortal.Application.TodoItems.Commands;

namespace PartnerPortal.WebApi.Controllers
{
    public class SalesPersonController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSalesPersonCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
