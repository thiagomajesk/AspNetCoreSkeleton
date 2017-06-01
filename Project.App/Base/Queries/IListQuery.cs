using MediatR;
using Project.Domain.Entities.Base;
using System.Collections.Generic;

namespace Project.App.Base.Queries
{
    /// <summary>
    /// Query that lists entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to list</typeparam>
    public interface IListQuery<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : Entity, new()
    {
        string[] Includes { get; set; }

        int Page { get; set; }

        int PageSize { get; set; }
    }
}