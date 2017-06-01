using MediatR;
using Project.App.Base.Queries;
using Project.Domain.Entities.Base;
using Project.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace Project.App.Base.Handlers
{
    /// <summary>
    /// Generic Handler that shows entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to show</typeparam>
    /// <typeparam name="TQuery">Show Query</typeparam>
    public class ShowQueryHandler<TEntity, TQuery> : IRequestHandler<TQuery, TEntity>
        where TEntity : Entity, new()
        where TQuery : IShowQuery<TEntity>, new()
    {
        private readonly DatabaseContext context;

        public ShowQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<TEntity> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var entity = context.Set<TEntity>().Find(request.Id);

            return Task.FromResult(entity);
        }
    }
}