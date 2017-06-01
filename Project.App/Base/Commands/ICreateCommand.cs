using MediatR;
using Project.Domain.Entities.Base;

namespace Project.App.Base.Commands
{
    /// <summary>
    /// Generic Command that creates entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to create</typeparam>
    public interface ICreateCommand<TEntity> : IRequest<TEntity> where TEntity : Entity, new()
    {
    }
}