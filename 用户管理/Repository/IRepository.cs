﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 用户管理.Repository
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        Task<T> GetByIdAsync(string id);
        Task<T> CreateAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
    }
}
