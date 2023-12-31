﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DAL.Repositories.Interface
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntitiy
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(int id);
        Task<bool> IsExist(int id);
    }
}
