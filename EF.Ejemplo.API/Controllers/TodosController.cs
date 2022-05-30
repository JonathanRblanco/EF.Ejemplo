using EF.Business.Commands;
using EF.Business.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Ejemplo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(TodoCreateCommandResponse))]
        public async Task<ActionResult<TodoCreateCommandResponse>> CreateTodoAsync([FromBody] TodoCreateCommand todoCreateCommand, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(todoCreateCommand, cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<TodoGetAllQueryResponse>))]
        public async Task<ActionResult<List<TodoGetAllQueryResponse>>> GetAllAync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new TodoGetAllQuery(), cancellationToken));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(TodoDeleteCommandResponse))]
        public async Task<ActionResult<TodoDeleteCommandResponse>> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new TodoDeleteCommand { Id = id }, cancellationToken));
        }
    }
}