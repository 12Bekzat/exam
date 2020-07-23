using Edu.Api.Responses;
using Edu.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.Api.Command
{
    public class CreateApplicationCommand : IRequest<ApplicationResponse>
    {
        public ApplicationDto ApplicationDto { get; set; }

        public CreateApplicationCommand(ApplicationDto applicationDto)
        {
            ApplicationDto = applicationDto;
        }
    }
}
