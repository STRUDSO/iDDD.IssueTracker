using System;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class DomainEventPublisher
    {
        public static Action<object> Thunk = o => { };

        public static void Publish(object message)
        {
            Thunk(message);
        }
    }
}