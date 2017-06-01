using AutoMapper;
using MediatR;
using Project.App.Base.Commands;
using Project.Domain.Entities.Base;
using Project.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace Project.App.Base.Handlers
{
    /// <summary>
    /// Generic Handler that creates entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to create</typeparam>
    /// <typeparam name="TCommand">Create Command</typeparam>
    public class CreateCommandHandler<TEntity, TCommand> : IRequestHandler<TCommand, TEntity>
        where TEntity : Entity, new()
        where TCommand : ICreateCommand<TEntity>, new()
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public CreateCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<TEntity> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<TCommand, TEntity>(request);

            context.Set<TEntity>().Add(entity);

            context.SaveChanges();

            return Task.FromResult(entity);
        }
    }
}