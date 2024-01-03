﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Magic.Words.Core.IRepository;

using Magic.Words.Core.Data;
using Microsoft.EntityFrameworkCore;


namespace Magic.Words.Core.Repository {
    public class Repository<T> : IRepository<T> where T : class {
        
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db) {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity) {
            dbSet.Add(entity);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter) {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null) {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity) {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entite) {
            dbSet.RemoveRange(entite);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null) {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}