﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Dummy.Commands;
using PartnerPortal.Application.TodoItems.Commands;
using PartnerPortal.Application.TodoLists.Commands;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{
    public class RequisitionJDController : ApiControllerBase
    {
        private readonly ApplicationDbContext _fullStackDbContext;
        public RequisitionJDController(ApplicationDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllPartners()
        {
            var partners = await _fullStackDbContext.RequisitionJDs.ToListAsync();
            return Ok(partners);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequisitionJDCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateDetails(Guid id, UpdateRequisitionJDDetailsCommand command)
        {
            if (id != command.RequisitionJDID)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteRequisitionJDCommand(id));

            return NoContent();
        }
    }
}
