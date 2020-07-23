using Edu.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Application.Interfaces
{
    public interface IApplicationRepository
    {
        ApplicationDto GetById(int id);
        ApplicationDto Create(ApplicationDto applicationDto);
        ApplicationDto Update(int id, ApplicationDto applicationDto);
        ApplicationDto Remove(int id);
    }
}
