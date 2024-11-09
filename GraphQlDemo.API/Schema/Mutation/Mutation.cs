using GraphQlDemo.API.DTO;
using GraphQlDemo.API.Services.Courses;
using HotChocolate.Subscriptions;

namespace GraphQlDemo.API.Schema.Mutation
{
    public class Mutation
    {
        private readonly CourseRepository _courseRepository;
        public Mutation(CourseRepository courseRepository)
        {
            // _courses = new List<CourseResult>();
            _courseRepository = courseRepository;
        }

        public async Task<CourseResult> CreateCoureseType(CourseInputType courseInputType, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Id = Guid.NewGuid(),
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstractorId = courseInputType.InstructorId
            };
            courseDTO = await _courseRepository.CreateCourse(courseDTO);
            CourseResult course = new CourseResult()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstractorId
            };

            await topicEventSender.SendAsync(nameof(Subscription.Subscription.CourseCreated), course);
            return course;
        }

        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType courseInputType, [Service] ITopicEventSender topicEventSender, CancellationToken cancellationToken)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Id = id,
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstractorId = courseInputType.InstructorId
            };
            courseDTO= await _courseRepository.UpdateCourse(courseDTO,cancellationToken);
            CourseResult course = new CourseResult()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstractorId
            };
            
            string updateCourse = $"{course.Id}_{nameof(Subscription.Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(updateCourse, course);
            return course;

        }
        public async Task< bool> DeleteCourse(Guid id)
        {
            return await  _courseRepository.DeleteCourse(id);
        }
    }
}
