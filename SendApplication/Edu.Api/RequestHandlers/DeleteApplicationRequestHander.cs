using Edu.Api.Command;
using Edu.Application.DTO;
using Edu.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Edu.Api.RequestHandlers
{
    public class DeleteApplicationRequestHander : IRequestHandler<DeleteApplicationCommand, ApplicationDto>
    {
        private readonly IApplicationRepository _applicationRepository;

        public DeleteApplicationRequestHander(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<ApplicationDto> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
        {
            var result = _applicationRepository.Remove(request.ApplicationId);

            return result;
        }
    }
}
