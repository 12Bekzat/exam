using Edu.Api.Command;
using Edu.Api.Responses;
using Edu.Application.Implementations;
using Edu.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Edu.Api.RequestHandlers
{
    public class CreateApplicationRequestHandler : IRequestHandler<CreateApplicationCommand, ApplicationResponse>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ILogger<CreateApplicationRequestHandler> _logger;

        public CreateApplicationRequestHandler(IApplicationRepository applicationRepository, ILogger<CreateApplicationRequestHandler> logger)
        {
            _applicationRepository = applicationRepository;
            _logger = logger;
        }

        public async Task<ApplicationResponse> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var result = _applicationRepository.Create(request.ApplicationDto);
            var response = new ApplicationResponse();

            if (result == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.ErrorMessage = "Not created";

                _logger.LogError("Not created");
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.StudentDto = result;
            }

            return response;
        }
    }
}
