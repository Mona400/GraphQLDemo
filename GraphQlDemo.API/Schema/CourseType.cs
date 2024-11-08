using GraphQlDemo.API.DataLoaders;
using GraphQlDemo.API.DTO;
using GraphQlDemo.API.Models;
using GraphQlDemo.API.Services.Instructor;

namespace GraphQlDemo.API.Schema
{
   
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        //[GraphQLNonNullType]
        public Guid InstractorId { get; set; }
        [GraphQLNonNullType]
        public async Task< InstractorType> Instractor([Service] InatructorDataLoader inatructorDataLoader)
        {
            InstructorDTO instructorDTO = await inatructorDataLoader.LoadAsync(InstractorId);
            return new InstractorType()
            {
                Id = instructorDTO.Id,  
                FirstName = instructorDTO.FirstName,
                LastName = instructorDTO.LastName,  
                Salary = instructorDTO.Salary,
            };
        }
        [GraphQLNonNullType]
        public IEnumerable<StudentType>? Students { get; set; }
    }
}
