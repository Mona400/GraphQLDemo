using GraphQlDemo.API.Schema.Mutation;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQlDemo.API.Schema.Subscription
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;
        [SubscribeAndResolve]

        public ValueTask<ISourceStream<CourseResult>> CourseUpdated(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{courseId}_{nameof(Subscription.CourseCreated)}";
            return topicEventReceiver.SubscribeAsync< CourseResult>(topicName);
        }
    }
}
