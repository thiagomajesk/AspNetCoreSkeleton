using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using System;
using System.Linq;

namespace Project.Infra.Queries
{
    public static class UserQueryableExtensions
    {
        public static User FindByCredentials(this DbSet<User> dbSet, string email, string password)
        {
            // HACK: For simplification purposes. Instead use 'SingleOrDefault()' when its garanteed
            //       that emails are unique
            return dbSet.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && u.Password.Equals(password));
        }
    }
}