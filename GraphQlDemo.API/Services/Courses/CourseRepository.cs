using GraphQlDemo.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace GraphQlDemo.API.Services.Courses
{
    public class CourseRepository
    {
        //factory ensure there any concurency essies
        private readonly IDbContextFactory<SchoolDbContext> _context;

        public CourseRepository(IDbContextFactory<SchoolDbContext> context)
        {
            _context = context;
        }
        public async Task<IEnumerable< CourseDTO>>GetAllCourse()
        {
            using (SchoolDbContext context = _context.CreateDbContext())
            {
             
                return await context.Courses
                    //.Include(x=>x.Instractor)
                    .ToListAsync();
            }
        }
        public async Task<CourseDTO> GetCourseById(Guid courseId)
        {
            using (SchoolDbContext context = _context.CreateDbContext())
            {

                return await context.Courses
                   // .Include(x => x.Instractor)
                  
                    .FirstOrDefaultAsync(x=>x.Id==courseId);
            }
        }
        public async Task<CourseDTO> CreateCourse(CourseDTO course)
        {
            using (SchoolDbContext context=_context.CreateDbContext())
            {
                context.Courses.Add(course);
               await context.SaveChangesAsync();
               return course;
            }
        }
        public async Task<CourseDTO> UpdateCourse(CourseDTO course)
        {
            using (SchoolDbContext context = _context.CreateDbContext())
            {
                context.Courses.Update(course);
               await context.SaveChangesAsync();
                return course;
            }
        }
        public async Task<bool> DeleteCourse(Guid id)
        {
            using (SchoolDbContext context = _context.CreateDbContext())
            {
                CourseDTO course =new CourseDTO()
                {
                    Id= id
                };

                
                context.Courses.Remove(course);
              return  await context.SaveChangesAsync()>0;
               
            }
        }
    }
}
