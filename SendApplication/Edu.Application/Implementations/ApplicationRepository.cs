using AutoMapper;
using Domain.DataAccess;
using Edu.Application.DTO;
using Edu.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Application.Implementations
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        private const int GetAllKey = 0;

        public ApplicationRepository(ApplicationContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public ApplicationDto Create(ApplicationDto applicationDto)
        {
            var application = _mapper.Map<Domain.Model.Models.Application>(applicationDto);

            var savedStudentEntry = _context.Applications.Add(application);
            var result = _context.SaveChanges();

            var createdApplicationDto = _mapper.Map<ApplicationDto>(savedStudentEntry.Entity);

            if (result > 0)
            {
                _cache.Set(createdApplicationDto.Id, createdApplicationDto,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            }

            return createdApplicationDto;
        }

        public ApplicationDto GetById(int id)
        {
            if (_cache.TryGetValue(id, out ApplicationDto studentDto)) return studentDto;

            var student = _context.Applications.Find(id);
            if (student == null) return null;

            studentDto = _mapper.Map<ApplicationDto>(student);
            _cache.Set(student.Id, studentDto,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));


            return studentDto;
        }

        public ApplicationDto Remove(int id)
        {
            var application = _context.Applications.Find(id);
            _context.Applications.Remove(application);
            _context.SaveChanges();

            return _mapper.Map<ApplicationDto>(application);
        }

        public ApplicationDto Update(int id, ApplicationDto applicationDto)
        {
            var application = _context.Applications.Find(id);

            application.Iin = applicationDto.Iin;
            application.Score = applicationDto.Score;
            application.MainProfile = applicationDto.MainProfile;
            application.SecondProfile = applicationDto.SecondProfile;
            application.College = applicationDto.College;

            _context.Applications.Update(application);
            _context.SaveChanges();

            return _mapper.Map<ApplicationDto>(application);
        }
    }
}
