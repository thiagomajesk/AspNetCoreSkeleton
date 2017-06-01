using MediatR;
using Project.App.Base.Commands;
using Project.Domain.Entities.Base;
using Project.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace Project.App.Base.Handlers
{
    /// <summary>
    /// Generic Handler that deletes entities
    /// </summary>
    /// <typeparam name="TEntity">Entity to delete</typeparam>
    /// <typeparam name="TCommand">Delete Command</typeparam>
    public class DeleteCommandHandler<TEntity, TCommand> : IRequestHandler<TCommand, TEntity>
        where TEntity : Entity, new()
        where TCommand : IDeleteCommand<TEntity>, new()
    {
        private readonly DatabaseContext context;

        public DeleteCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<TEntity> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = context.Set<TEntity>().Find(request.Id);

            context.Set<TEntity>().Remove(entity);

            context.SaveChanges();

            return Task.FromResult(entity);
        }
    }
}