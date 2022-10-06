using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Helpers;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DataContext _context;

    public GenericRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().AsNoTracking();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Update(int id, TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
