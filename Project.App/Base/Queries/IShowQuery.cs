using MediatR;
using Project.Domain.Entities.Base;

namespace Project.App.Base.Queries
{
    /// <summary>
    /// Generic Query that shows entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to show</typeparam>
    public interface IShowQuery<TEntity> : IRequest<TEntity> where TEntity : Entity, new()
    {
        int Id { get; set; }
    }
}