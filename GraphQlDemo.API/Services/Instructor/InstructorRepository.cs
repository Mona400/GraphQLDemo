using GraphQlDemo.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace GraphQlDemo.API.Services.Instructor
{
    public class InstructorRepository
    {

        //factory ensure there any concurency essies
        private readonly IDbContextFactory<SchoolDbContext> _context;

        public InstructorRepository(IDbContextFactory<SchoolDbContext> context)
        {
            _context = context;
        }
        
        public async Task<InstructorDTO> GetInstructorById(Guid instructorId)
        {
            using (SchoolDbContext context = _context.CreateDbContext())
            {

                return await context.Instractors
                    // .Include(x => x.Instractor)

                    .FirstOrDefaultAsync(x => x.Id == instructorId );
            }
        }

        public async Task <IEnumerable<InstructorDTO>>GetManyByIds(IReadOnlyList<Guid> instructorIds)
        {
            using (SchoolDbContext context = _context.CreateDbContext())
            {

                return await context.Instractors
                    // .Include(x => x.Instractor)

                    .Where(x => instructorIds.Contains(x.Id)).ToListAsync();
            }
        }
        
        
    }
}

