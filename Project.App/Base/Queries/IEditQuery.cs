using MediatR;
using Project.App.Base.Commands;
using Project.Domain.Entities.Base;

namespace Project.App.Base.Queries
{
    /// <summary>
    /// Generic Query that edits entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to edit</typeparam>
    /// <typeparam name="TCommand">Update Command</typeparam>
    public interface IEditQuery<TEntity, TCommand> : IRequest<TCommand>
        where TEntity : Entity, new()
        where TCommand : IUpdateCommand<TEntity>
    {
        int Id { get; set; }
    }
}