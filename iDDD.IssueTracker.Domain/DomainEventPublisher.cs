using System;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class DomainEventPublisher
    {
        public static Action<object> Thunk = o => { };

        public static void Publish(object message)
        {
            if (message == null) throw new ArgumentNullException("message");
            Thunk(message);
        }
    }
}