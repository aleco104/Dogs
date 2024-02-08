using ClassLibrary1.Contexts;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ClassLibrary1.ProductRepositories;

public class ProductRepo<TEntity> where TEntity : class
{
    private readonly ProductContext _context;

    protected ProductRepo(ProductContext context)
    {
        _context = context;
    }

    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }

    public virtual TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate)!;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToList();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }

    public virtual TEntity Update(Expression<Func<TEntity, bool>> predicate, TEntity newEntity)
    {
        try
        {
            var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(newEntity);
                _context.SaveChanges();

                return entityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return null!;
    }

    public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();

                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR: " + ex.Message); }
        return false;
    }
}
