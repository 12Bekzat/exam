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
    public class UpdateApplicationRequestHandler : IRequestHandler<UpdateApplicationCommand, ApplicationDto>
    {
        private readonly IApplicationRepository _applicationRepository;

        public UpdateApplicationRequestHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<ApplicationDto> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
        {
            var result = _applicationRepository.Update(request.Id, request.ApplicationDto);

            return result;
        }
    }
}
