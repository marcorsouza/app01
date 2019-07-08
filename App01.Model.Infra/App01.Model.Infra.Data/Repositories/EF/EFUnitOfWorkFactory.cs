using App01.Model.Domain;
using App01.Model.Infra.Data.Context.EF;

namespace App01.Model.Infra.Data.Repositories.EF
{
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly MyContext _context;

        public EFUnitOfWorkFactory(MyContext context)
        {
            _context = context;
        }

        #region IUnitOfWorkFactory Members

        public IUnitOfWork Create()
        {
            return new EFUnitOfWork(_context);
        }

        #endregion
    }
}