using Microsoft.EntityFrameworkCore;

namespace Common.Repository;

public class RepositoryBase<T>(BaseDbContext _context) : IRepositoryBase<T> where T : class
{
    public virtual async Task<List<T>> GetAllAsync()
    {
        try
        {
            return await _context.Set<T>().ToListAsync();
        }
        catch (Exception ex)
        {
            throw new IOException("Error occurred while retrieving data.", ex);
        }
    }

    public virtual async Task<T?> GetByIdAsync(object id)
    {
        try
        {
            var entity = await _context.Set<T>().FindAsync(id) ??
                throw new ObjectNotFoundException($"Entity of type {typeof(T).Name} " +
                $"with ID {id} not found.");

            return entity ?? null;
        }
        catch (Exception ex)
        {
            throw new IOException("Error occurred while retrieving data by ID.", ex);
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
        catch (DbUpdateException ex)
        {
            throw new DbUpdateException("Error occurred while creating entity.", ex);
        }
        catch (Exception ex)
        {
            throw new IOException("Error occurred while creating entity.", ex);
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
            throw new InvalidOperationException("Concurrency error occurred while updating entity.", ex);
        }
        catch (Exception ex)
        {
            throw new IOException("Error occurred while updating entity.", ex);
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
        catch (DbUpdateException ex)
        {
            throw new DbUpdateException("Error occurred while deleting entity.", ex);
        }
        catch (Exception ex)
        {
            throw new IOException("Error occurred while deleting entity.", ex);
        }
    }
}
