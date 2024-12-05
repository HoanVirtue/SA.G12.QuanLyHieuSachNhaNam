using AutoMapper;
using Domain.ModelViews;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<Pagination<T>> GetGridAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? pageIndex = null,
            int? pageSize = null);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetByIdAsync(object id, Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entities);
        Task DeleteAsync(object id);
        Task Delete(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
    }

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected QuanLyHieuSachNhaNamContext _dbContext;
        protected DbSet<T> _dbSet;
        private QuanLyHieuSachNhaNamContext dbContext;
        protected readonly IMapper _mapper;

        public GenericRepository(QuanLyHieuSachNhaNamContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _mapper = mapper;
        }

        // Get all with filter, order by, include properties or not
        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<Pagination<T>> GetGridAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? pageIndex = null,
            int? pageSize = null)
        {
            try
            {
                IQueryable<T> query = _dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    query = orderBy(query);
                }
                int? totalItemsCount = 0;
                try
                {
                    totalItemsCount = await query.CountAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    }
                }
                //int? totalItemsCount = await query.CountAsync();

                if (pageIndex.HasValue && pageIndex.Value == -1)
                {
                    pageSize = totalItemsCount; // Set pageSize to total count
                    pageIndex = 0; // Reset pageIndex to 0
                }
                else if (pageIndex.HasValue && pageSize.HasValue)
                {
                    int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value : 0;
                    int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                    query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
                }

                var items = await query.ToListAsync();

                return new Pagination<T>
                {
                    TotalItemsCount = totalItemsCount ?? 0,
                    PageSize = pageSize ?? totalItemsCount ?? 0,
                    PageIndex = pageIndex ?? 0,
                    Items = items
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(object id, Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            // Filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include properties
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var keyName = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, keyName);
            var equal = Expression.Equal(property, Expression.Constant(id));
            var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);

            return await query.FirstOrDefaultAsync(lambda);
        }

        // Add entity
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Add range of entities
        public async Task AddRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        // Update entity
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Update range of entities
        public async Task UpdateRangeAsync(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        // Delete entity by Id
        public async Task DeleteAsync(object id)
        {
            T entityToDelete = _dbSet.Find((string)id);
            if (entityToDelete != null)
                await Delete(entityToDelete);
        }

        // Delete entity
        public async Task Delete(T entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();
        }

        // Count entities with filter
        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
