using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.App.Base.Queries;
using Project.Domain.Entities.Base;
using Project.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.App.Base.Handlers
{
    /// <summary>
    /// Generic Handler that lists entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to list</typeparam>
    /// <typeparam name="TQuery">List Query</typeparam>
    public class ListQueryHandler<TEntity, TQuery> : IRequestHandler<TQuery, IEnumerable<TEntity>>
        where TEntity : Entity, new()
        where TQuery : IListQuery<TEntity>, new()
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public ListQueryHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<IEnumerable<TEntity>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            request.Page = request.Page > 0 ? request.Page : 1;
            request.PageSize = request.PageSize > 0 ? request.PageSize : 10;

            var entites = context.Set<TEntity>()
                .AsQueryable()
                .AsNoTracking()
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .AsEnumerable();

            return Task.FromResult(entites);
        }
    }
}