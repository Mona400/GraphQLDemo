using HotChocolate.Data.Sorting;

namespace GraphQlDemo.API.Schema.Sorters
{
    public class CourseSortType:SortInputType<CourseType>
    {
        protected override void Configure(ISortInputTypeDescriptor<CourseType> descriptor)
        {
            descriptor.Ignore(c=>c.Id);
            descriptor.Ignore(c=>c.InstractorId);
            descriptor.Field(c=>c.Name).Name("CourseName");
            base.Configure(descriptor);
        }
    }
}
