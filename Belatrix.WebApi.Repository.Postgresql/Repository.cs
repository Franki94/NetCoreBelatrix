﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Repository.Postgresql
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BelatrixDbContext _context;
        public Repository(BelatrixDbContext context)
        {
            _context = context;
        }
        public  async Task<int> Create(T entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> Read()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
