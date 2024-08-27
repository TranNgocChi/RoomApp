﻿using UserService.Common;

namespace UserService.Repository.Intention;

public interface IRepositoryBase<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(object id);
    Task<T?> CreateAsync(T entity);
    Task<OperationResult> UpdateAsync(T entity);
    Task<OperationResult> DeleteAsync(T entity);
}
