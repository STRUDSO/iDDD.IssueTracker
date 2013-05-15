namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IHaveId<out T>
    {
        T Id { get; }
    }
}