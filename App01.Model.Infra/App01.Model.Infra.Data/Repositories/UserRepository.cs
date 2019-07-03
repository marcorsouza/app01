using App01.Model.Domain.Entities;
using App01.Model.Infra.Data.Context.EF;
using App01.Model.Infra.Data.Repositories.EF;

namespace App01.Model.Infra.Data.Repositories {
    public class UserRepository : Repository<User> {
        public UserRepository (IEFUnitOfWork unitOfWork) : base (unitOfWork) { }

        public UserRepository () : base (new EFUnitOfWork (new MySqlContext ())) { }
    }
}