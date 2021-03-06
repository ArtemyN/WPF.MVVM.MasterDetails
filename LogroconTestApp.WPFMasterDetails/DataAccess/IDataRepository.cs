﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IDataRepository<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T Get(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void InsertMany(params T[] items);
        void Update(params T[] items);
        void Delete(params T[] items);
    }
}