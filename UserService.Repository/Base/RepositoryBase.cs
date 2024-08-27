using Microsoft.EntityFrameworkCore;
using UserService.Common;
using UserService.Database;
using UserService.Repository.Intention;

namespace UserService.Repository;

public class RepositoryBase<T> : SingletonBase<RepositoryBase<T>>, IRepositoryBase<T> where T : class
{
    private readonly UserServiceContext _context = new();
    public virtual async Task<List<T>> GetAllAsync()
    {
        try
        {
            return await _context.Set<T>().ToListAsync(); 
        }
        catch (Exception ex)
        {
            throw new Common.IOException("Error occurred while retrieving data.", ex);
        }
    }

    public virtual async Task<T?> GetByIdAsync(object id)
    {
        try
        {
            var entity = await _context.Set<T>().FindAsync(id) ??
                throw new ObjectNotFoundException($"Entity of type {typeof(T).Name} " +
                $"with ID {id} not found.");
            
            return entity;
        }
        catch (Exception ex)
        {
            throw new Common.IOException("Error occurred while retrieving data by ID.", ex);
        }
    }

    public virtual async Task<T?> CreateAsync(T entity)
    {
        try
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Common.DbUpdateException ex)
        {
            throw new Common.DbUpdateException("Error occurred while creating entity.", ex);
        }
        catch (Exception ex)
        {
            throw new Common.IOException("Error occurred while creating entity.", ex);
        }
    }

    public virtual async Task<OperationResult> UpdateAsync(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new OperationResult
            {
                Message = "",
                Result = true
            };
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new Common.InvalidOperationException("Concurrency error occurred while updating entity.", ex);
        }
        catch (Exception ex)
        {
            throw new Common.IOException("Error occurred while updating entity.", ex);
        }
    }

    public virtual async Task<OperationResult> DeleteAsync(T entity)
    {
        try
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return new OperationResult
            {
                Message = "",
                Result = true
            };
        }
        catch (Common.DbUpdateException ex)
        {
            throw new Common.DbUpdateException("Error occurred while deleting entity.", ex);
        }
        catch (Exception ex)
        {
            throw new Common.IOException("Error occurred while deleting entity.", ex);
        }
    }
}
