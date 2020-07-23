using Edu.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.Api.Command
{
    public class DeleteApplicationCommand : IRequest<ApplicationDto>
    {
        public int ApplicationId { get; set; }

        public DeleteApplicationCommand(int id)
        {
            ApplicationId = id;
        }
    }
}
