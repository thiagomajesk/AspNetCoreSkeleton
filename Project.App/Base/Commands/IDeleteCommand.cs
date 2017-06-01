using MediatR;
using Project.Domain.Entities.Base;

namespace Project.App.Base.Commands
{
    /// <summary>
    /// Generic Command that deletes entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to delete</typeparam>
    public interface IDeleteCommand<TEntity> : IRequest<TEntity> where TEntity : Entity, new()
    {
        int Id { get; set; }
    }
}