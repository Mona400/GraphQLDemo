using Bogus;
using GraphQlDemo.API.DTO;
using GraphQlDemo.API.Models;
using GraphQlDemo.API.Services;
using GraphQlDemo.API.Services.Courses;
using System;
using System.Collections;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using GraphQlDemo.API.Schema.Filters;
namespace GraphQlDemo.API.Schema.Query
{
    public class Query
    {
        private readonly CourseRepository _courseRepository;
        public Query(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        #region Seed Data
        //private readonly Faker<InstractorType> _instractorFaker;
        //private readonly Faker<StudentType> _studentFaker;
        //private readonly Faker<CourseType> _courseFaker;

        //public Query()
        //{
        //    _instractorFaker = new Faker<InstractorType>()
        //        .RuleFor(c => c.Id, f => Guid.NewGuid())
        //        .RuleFor(c => c.FirstName, f => f.Name.FirstName())
        //        .RuleFor(c => c.LastName, f => f.Name.LastName())
        //        .RuleFor(c => c.Salary, f => f.Random.Double(1, 10000));

        //    _studentFaker = new Faker<StudentType>()
        //        .RuleFor(c => c.Id, f => Guid.NewGuid())
        //        .RuleFor(c => c.FirstName, f => f.Name.FirstName())
        //        .RuleFor(c => c.LastName, f => f.Name.LastName())
        //        .RuleFor(c => c.GPA, f => f.Random.Double(1, 4));

        //    _courseFaker = new Faker<CourseType>()
        //        .RuleFor(c => c.Id, f => Guid.NewGuid())
        //        .RuleFor(c => c.Name, f => f.Name.JobType())
        //        .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
        //        .RuleFor(c => c.Instractor, f => _instractorFaker.Generate())
        //        .RuleFor(c => c.Students, f => _studentFaker.Generate(5));
        //}
        //public IEnumerable<CourseType> GetCourseTypes()
        //{
        //    return _courseFaker.Generate(5);
        //}
        //public async Task<CourseType> GetCourseTypeByIdAsync(Guid Id)
        //{
        //    CourseType course = _courseFaker.Generate();
        //    course.Id = Id;
        //    return course;

        //}
        #endregion
      
        [UsePaging(IncludeTotalCount =true,DefaultPageSize =10)]
        [UseFiltering]
        public async Task< IEnumerable<CourseType>> GetCourseTypes()
        {
            IEnumerable<CourseDTO> courseDTO= await _courseRepository.GetAllCourse();
            return courseDTO.Select(c=> new CourseType()
            {
                Id = c.Id,
                Name = c.Name,
                InstractorId = c.InstractorId,
                Subject = c.Subject,
               
                
            });
        }
        [UseDbContext(typeof(SchoolDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseFiltering]
        //[UseFiltering(typeof(CourseFilterType))]
        public IQueryable<CourseType> GetPaginatedCourseTypes([ScopedService ] SchoolDbContext context)
        {
            
            return context.Courses.Select(c => new CourseType()
            {
                Id = c.Id,
                Name = c.Name,
                InstractorId = c.InstractorId,
                Subject = c.Subject,
               

            });
        }
        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        public async Task<IEnumerable<CourseType>> GetOffsetCourseTypes()
        {
            IEnumerable<CourseDTO> courseDTO = await _courseRepository.GetAllCourse();
            return courseDTO.Select(c => new CourseType()
            {
                Id = c.Id,
                Name = c.Name,
                InstractorId = c.InstractorId,
                Subject = c.Subject,
               

            });
        }

        public async Task<CourseType> GetCourseTypeByIdAsync(Guid Id)
        {
          CourseDTO courseDTO = await _courseRepository.GetCourseById(Id);
            return new CourseType()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                InstractorId = courseDTO.InstractorId,
                Subject = courseDTO.Subject,
                //Instractor = new InstractorType
                //{
                //    Id = courseDTO.InstractorId,
                //    FirstName = courseDTO.Instractor.FirstName,
                //    LastName = courseDTO.Instractor.LastName,
                //    Salary = courseDTO.Instractor.Salary,

                //}

            };

        }
        [GraphQLDeprecated("This query is deprecated")]
        public string Instraction => "Like and Subscribe To New Channel CSMona";
    }
}
