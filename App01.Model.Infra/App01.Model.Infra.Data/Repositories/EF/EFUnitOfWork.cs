using Microsoft.EntityFrameworkCore;
using App01.Model.Infra.Data.Context.EF;
using System.Threading.Tasks;

namespace App01.Model.Infra.Data.Repositories.EF
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        public EFUnitOfWork(MyContext context)
        {
            Context = context;
        }

        public DbContext Context { get;set; }

        //public void BeginTransaction()
        //{
        //    throw new System.NotImplementedException();
        //}

        public bool Commit()
        {
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> CommitSync()
        {
            return await Context.SaveChangesAsync() > 0;
        }

        //public void Rollback()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public bool WasCommitted()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}