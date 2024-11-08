using GraphQlDemo.API.Models;

namespace GraphQlDemo.API.Schema.Mutation
{
    public class CourseInputType
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
    }
}
