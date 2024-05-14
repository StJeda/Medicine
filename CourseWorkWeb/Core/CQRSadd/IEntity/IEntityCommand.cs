namespace CourseWorkWeb.Core.CQRS_.IEntity
{
    public interface IEntityCommand
    {
        int EntityId { get; set; }
        object Entity { get; }
    }
}
