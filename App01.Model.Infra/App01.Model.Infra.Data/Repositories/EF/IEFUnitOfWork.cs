using App01.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace App01.Model.Infra.Data.Repositories.EF
{
    public interface IEFUnitOfWork : IUnitOfWork<DbContext>
    {
    }
}