using CarBookingData;
using CarBookingData.DataModels;
using Microsoft.EntityFrameworkCore.Query;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAll(
            Expression<Func<TEntity, bool>>? expression = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include=null
        );

        Task<TEntity> Get(
            Expression<Func<TEntity, bool>>? expression,
            //List<string> include = null);
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        Task<IPagedList<TEntity>> GetPagedList(
            RequestParams requestParams,
            List <string> includes = null
            );
        Task Insert(TEntity entity);
        Task InsertRange(IEnumerable<TEntity> entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<bool> Exists(int id);
    }
}
