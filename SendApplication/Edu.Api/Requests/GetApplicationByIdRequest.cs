using Edu.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.Api.Requests
{
    public class GetApplicationByIdRequest : IRequest<ApplicationDto>
    {
        public int ApplicationId { get; set; }

        public GetApplicationByIdRequest(int id)
        {
            ApplicationId = id;
        }
    }
}
