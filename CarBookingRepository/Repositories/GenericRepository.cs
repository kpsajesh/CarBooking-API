using CarBookingData.DataModels;
using CarBookingRepository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Repositories
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {  
        private readonly CarBookingDbContext _context;
        private readonly DbSet<TEntity> _db;

        public GenericRepository(CarBookingDbContext context)
        {
            _context=context;
            _db = _context.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> query = _db;

            if(expression!=null)
            {
                query=query.Where(expression);
            }

            if (include != null)
            {
                query = include(query);
            }
            if(orderBy!=null)
            {
                query=orderBy(query);
            }
            //if(expression!=null)
            return await query.AsNoTracking().ToListAsync();
        }


        public async Task<TEntity> Get(Expression<Func<TEntity, bool>>? expression, 
            //List<string> include = null)
            Func<IQueryable<TEntity>,IIncludableQueryable<TEntity, object>>? include = null)
            
        {
            IQueryable<TEntity> query = _db;

            if(include!= null)
            {
               /* foreach (var includeProperty in include)
                {
                    query = query.Include(includeProperty);
                }*/
                query = include(query);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }


        public async Task<IPagedList<TEntity>> GetPagedList(
            RequestParams requestParams,
            List<string> includes = null
            )
        {
            IQueryable<TEntity> query = _db;

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
                //query = includes(query);
            }
            return await query.AsNoTracking()
                .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }


        public async Task Insert(TEntity entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<TEntity> entities)
        {
            await _db.AddRangeAsync(entities);
        }     

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            if (entity != null)
                _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }


        /*public async Task<int> SaveChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries<BaseDomainEntity>().Where(q => q.State == EntityState.Added))
            {
                entry.Entity.CreatedDate = DateTime.Now;
            }
            foreach (var entry in _context.ChangeTracker.Entries<BaseDomainEntity>().Where(q => q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedDate = DateTime.Now;
            }
            foreach (var entry in _context.ChangeTracker.Entries<BaseDomainEntity>().Where(q => q.State == EntityState.Deleted))
            {
                //entry.Entity.UpdatedDate = DateTime.Now;
            }
            return await _context.SaveChangesAsync();
        }*/
    }
}
