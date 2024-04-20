﻿using System.Linq.Expressions;
using MessengerX.Domain.Entities;

namespace MessengerX.Domain.Interfaces.Repository;

public interface IAsyncRepository<TEntity>
    where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties
    );
    Task<IEnumerable<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>?> GetAllAsync();
    Task<IEnumerable<TEntity>?> GetAllAsync(
        params Expression<Func<TEntity, object>>[] includeProperties
    );
    Task<IEnumerable<TEntity>?> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties
    );
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IQueryable<TEntity>> CustomAsync();
}
