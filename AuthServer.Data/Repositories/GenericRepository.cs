using AuthServer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data.Repositories
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Tentity> _dbset;

        public GenericRepository(AppDbContext context)
        {
            _dbContext= context;
            _dbset = context.Set<Tentity>();
        }
        public async Task AddAsync(Tentity entity)
        {
            await _dbset.AddAsync(entity);

        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
           return await _dbset.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            //bu datayı bulduğunda silme ve güncelleme esnasında EntityState.Detached yapısı ile takip edilmesini önler

            if (entity!=null)
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public void Remove(Tentity entity)
        {
            _dbset.Remove(entity);
        }

        public Tentity Update(Tentity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; 
            return entity;
        }

        public IQueryable<Tentity> Where(System.Linq.Expressions.Expression<Func<Tentity, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }
    }
}
