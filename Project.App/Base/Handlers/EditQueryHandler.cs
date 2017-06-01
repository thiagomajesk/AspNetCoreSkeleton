using AutoMapper;
using MediatR;
using Project.App.Base.Commands;
using Project.App.Base.Queries;
using Project.Domain.Entities.Base;
using Project.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace Project.App.Base.Handlers
{
    /// <summary>
    /// Generic Handler that edits entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to edit</typeparam>
    /// <typeparam name="TQuery">Edit Query</typeparam>
    /// <typeparam name="TCommand">Update Command</typeparam>
    public class EditEntityQueryHandler<TEntity, TQuery, TCommand> : IRequestHandler<TQuery, TCommand>
        where TEntity : Entity, new()
        where TQuery : IEditQuery<TEntity, TCommand>, new()
        where TCommand : IUpdateCommand<TEntity>, new()
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public EditEntityQueryHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<TCommand> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var entity = context.Set<TEntity>().Find(request.Id);

            var command = mapper.Map<TEntity, TCommand>(entity);

            return Task.FromResult(command);
        }
    }
}