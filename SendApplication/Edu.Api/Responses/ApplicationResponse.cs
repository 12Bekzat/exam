using Edu.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Edu.Api.Responses
{
    public class ApplicationResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public ApplicationDto StudentDto { get; set; }
        public string ErrorMessage { get; set; }
    }
}
