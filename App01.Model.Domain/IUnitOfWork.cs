using System.Threading.Tasks;

namespace App01.Model.Domain
{
    public interface IUnitOfWork
    {
        //void BeginTransaction();
        bool Commit();
        Task<bool> CommitSync();
        //void Rollback();
        //bool WasCommitted();
    }

    public interface IUnitOfWork<T> : IUnitOfWork
    {
        T Context { get; set; }
    }
}