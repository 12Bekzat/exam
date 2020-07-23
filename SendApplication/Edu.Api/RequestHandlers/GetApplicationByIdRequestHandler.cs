using Edu.Api.Requests;
using Edu.Api.Responses;
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
    public class GetApplicationByIdRequestHandler : IRequestHandler<GetApplicationByIdRequest, ApplicationDto>
    {
        private readonly IApplicationRepository _applicationRepository;

        public GetApplicationByIdRequestHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<ApplicationDto> Handle(GetApplicationByIdRequest request, CancellationToken cancellationToken)
        {
            var result = _applicationRepository.GetById(request.ApplicationId);

            return result;
        }
    }
}
