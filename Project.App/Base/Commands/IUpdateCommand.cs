using MediatR;
using Project.Domain.Entities.Base;

namespace Project.App.Base.Commands
{
    /// <summary>
    /// Generic Command that updates entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to update</typeparam>
    public interface IUpdateCommand<TEntity> : IRequest<TEntity> where TEntity : Entity, new()
    {
        int Id { get; set; }
    }
}