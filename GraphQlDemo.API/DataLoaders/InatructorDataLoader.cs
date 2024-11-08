using GraphQlDemo.API.DTO;
using GraphQlDemo.API.Services.Instructor;

namespace GraphQlDemo.API.DataLoaders
{
    //use this insteted of load data using include 
    public class InatructorDataLoader : BatchDataLoader<Guid, InstructorDTO>
    {
        private readonly InstructorRepository _instructorRepository;
        public InatructorDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, InstructorRepository instructorRepository = null) : base(batchScheduler, options)
        {
            _instructorRepository = instructorRepository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, InstructorDTO>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
          IEnumerable<InstructorDTO> instructors=await  _instructorRepository.GetManyByIds(keys);
            return instructors.ToDictionary(i=>i.Id);
        }
    }
}
