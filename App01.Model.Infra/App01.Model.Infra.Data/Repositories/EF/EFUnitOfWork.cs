using Microsoft.EntityFrameworkCore;
using App01.Model.Infra.Data.Context.EF;
using System.Threading.Tasks;

namespace App01.Model.Infra.Data.Repositories.EF
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        public EFUnitOfWork(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get;set; }

        public void BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitSync()
        {
            await Context.SaveChangesAsync();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }

        public bool WasCommitted()
        {
            throw new System.NotImplementedException();
        }
    }
}