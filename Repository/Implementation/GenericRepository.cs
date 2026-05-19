using Microsoft.EntityFrameworkCore;
using StudentCRUD.Models.Context;
namespace StudentCRUD.Repository.Interface;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDBContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDBContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new Exception("User Not Found");
        }

        return entity;
    }

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}