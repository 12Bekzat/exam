using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Edu.Api.Command;
using Edu.Api.Requests;
using Edu.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetApplicationByIdRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationDto applicationDto)
        {
            var createApplicationCommand = new CreateApplicationCommand(applicationDto);
            var response = await _mediator.Send(createApplicationCommand);

            return response.StatusCode == HttpStatusCode.NotFound
                ? (IActionResult)NotFound(response)
                : Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ApplicationDto applicationDto)
        {
            var updateApplicationCommand = new UpdateApplicationCommand(id, applicationDto);
            var response = await _mediator.Send(updateApplicationCommand);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteApplicationCommand = new DeleteApplicationCommand(id);
            var response = await _mediator.Send(deleteApplicationCommand);
            return Ok(response);
        }
    }
}
