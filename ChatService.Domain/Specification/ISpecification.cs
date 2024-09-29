﻿using System.Linq.Expressions;
using ChatService.Domain.Entities;

namespace ChatService.Domain.Specification;

public interface ISingleSpecification<TEntity>
    where TEntity : BaseEntity
{
    Expression<Func<TEntity, bool>>? Criteria { get; }
    ICollection<Expression<Func<TEntity, object?>>> Includes { get; }
    ICollection<string> IncludeStrings { get; }
    bool IsAsNoTracking { get; }
}

public interface ISpecification<TEntity> : ISingleSpecification<TEntity>
    where TEntity : BaseEntity
{
    Expression<Func<TEntity, object>>? OrderBy { get; }
    Expression<Func<TEntity, object>>? OrderByDescending { get; }
    Expression<Func<TEntity, object>>? GroupBy { get; }
}
