using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities.Base;
using System;
using System.Linq;

namespace Project.Infra.Queries
{
    /// <summary>
    /// Extensions to be used as custom queries
    /// </summary>
    public static class EntityQueryExtensions
    {
        public static IQueryable<Entity> CreatedInTheLast24H<TEntity>(this DbSet<TEntity> dbSet) where TEntity : Entity
        {
            return dbSet.Where(e => e.CreatedOn >= DateTime.Now.AddDays(-24));
        }
    }
}