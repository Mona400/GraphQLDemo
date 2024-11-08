using GraphQlDemo.API.Models;
using GraphQlDemo.API.Schema;

namespace GraphQlDemo.API.DTO
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
       
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstractorId { get; set; }
        //[GraphQLNonNullType]
        public InstructorDTO Instractor { get; set; }
        // public Guid CourseAndStudentDTOId { get; set; }
        [GraphQLNonNullType]
        public IEnumerable<CourseAndStudentDTO>? CourseAndStudentDTO { get; set; }
       // public IEnumerable<StudentDTO> Students { get; set; }
    }
}
