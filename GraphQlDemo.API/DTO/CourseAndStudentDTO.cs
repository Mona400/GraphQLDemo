namespace GraphQlDemo.API.DTO
{
    public class CourseAndStudentDTO
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public CourseDTO Course { get; set; }
        public StudentDTO Student { get; set; }
    }
}
