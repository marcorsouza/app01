using App01.Model.Domain;
using App01.Model.Infra.Data.Context.EF;

namespace App01.Model.Infra.Data.Repositories.EF
{
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly MySqlContext _context;

        public EFUnitOfWorkFactory(MySqlContext context)
        {
            _context = context;
        }

        public EFUnitOfWorkFactory()
        {
            _context = new MySqlContext();
        }

        #region IUnitOfWorkFactory Members

        public IUnitOfWork Create()
        {
            return new EFUnitOfWork(_context);
        }

        #endregion
    }
}