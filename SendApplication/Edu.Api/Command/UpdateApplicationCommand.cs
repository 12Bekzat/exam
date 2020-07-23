using Edu.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.Api.Command
{
    public class UpdateApplicationCommand : IRequest<ApplicationDto>
    {
        public ApplicationDto ApplicationDto { get; set; }
        public int Id { get; set; }

        public UpdateApplicationCommand(int id, ApplicationDto applicationDto)
        {
            Id = id;
            ApplicationDto = applicationDto;
        }
    }
}
