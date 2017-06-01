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
    /// Handler generico para atualizar entidades
    /// </summary>
    /// <typeparam name="TEntity">Entity to update</typeparam>
    /// <typeparam name="TCommand">Update Command</typeparam>
    public class UpdateCommandHandler<TEntity, TCommand> : IRequestHandler<TCommand, TEntity>
        where TEntity : Entity, new()
        where TCommand : IUpdateCommand<TEntity>, new()
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UpdateCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<TEntity> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<TCommand, TEntity>(request);

            var entities = context.Set<TEntity>().Update(entity);

            context.SaveChanges();

            return Task.FromResult(entity);
        }
    }
}