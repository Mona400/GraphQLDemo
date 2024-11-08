namespace GraphQlDemo.API.DTO
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double GPA { get; set; }
        //  public Guid CourseAndStudentDTOId { get; set; }
        public IEnumerable<CourseAndStudentDTO> CourseAndStudentDTO { get; set; }
       // public CourseAndStudentDTO CourseAndStudentDTO { get; set; }
        //public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
