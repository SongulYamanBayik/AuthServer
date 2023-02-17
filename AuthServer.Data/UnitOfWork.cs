using AuthServer.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbcontext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _dbcontext= appDbContext;
        }
        public void Commit()
        {
            _dbcontext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
