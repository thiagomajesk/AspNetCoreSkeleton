using Autofac;
using MediatR;
using Project.App.Base.Handlers;
using Project.App.Features.Post.Commands;
using Project.App.Features.Post.Queries;
using Project.App.Features.User.Commands;
using Project.App.Features.User.Queries;
using System.Collections.Generic;

namespace Project.App.Config.AutoFac
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // User
            builder.RegisterType<CreateCommandHandler<Domain.Entities.User, CreateUserCommand>>()
                .As<IRequestHandler<CreateUserCommand, Domain.Entities.User>>();

            builder.RegisterType<DeleteCommandHandler<Domain.Entities.User, DeleteUserCommand>>()
                .As<IRequestHandler<DeleteUserCommand, Domain.Entities.User>>();

            builder.RegisterType<EditEntityQueryHandler<Domain.Entities.User, EditUserQuery, UpdateUserCommand>>()
                .As<IRequestHandler<EditUserQuery, UpdateUserCommand>>();

            builder.RegisterType<ListQueryHandler<Domain.Entities.User, ListUserQuery>>()
                .As<IRequestHandler<ListUserQuery, IEnumerable<Domain.Entities.User>>>();

            builder.RegisterType<ShowQueryHandler<Domain.Entities.User, ShowUserQuery>>()
                .As<IRequestHandler<ShowUserQuery, Domain.Entities.User>>();

            builder.RegisterType<UpdateCommandHandler<Domain.Entities.User, UpdateUserCommand>>()
                .As<IRequestHandler<UpdateUserCommand, Domain.Entities.User>>();

            // Post
            builder.RegisterType<CreateCommandHandler<Domain.Entities.Post, CreatePostCommand>>()
                .As<IRequestHandler<CreatePostCommand, Domain.Entities.Post>>();

            builder.RegisterType<DeleteCommandHandler<Domain.Entities.Post, DeletePostCommand>>()
                .As<IRequestHandler<DeletePostCommand, Domain.Entities.Post>>();

            builder.RegisterType<EditEntityQueryHandler<Domain.Entities.Post, EditPostQuery, UpdatePostCommand>>()
                .As<IRequestHandler<EditPostQuery, UpdatePostCommand>>();

            builder.RegisterType<ListQueryHandler<Domain.Entities.Post, ListPostQuery>>()
                .As<IRequestHandler<ListPostQuery, IEnumerable<Domain.Entities.Post>>>();

            builder.RegisterType<ShowQueryHandler<Domain.Entities.Post, ShowPostQuery>>()
                .As<IRequestHandler<ShowPostQuery, Domain.Entities.Post>>();

            builder.RegisterType<UpdateCommandHandler<Domain.Entities.Post, UpdatePostCommand>>()
                .As<IRequestHandler<UpdatePostCommand, Domain.Entities.Post>>();
        }
    }
}