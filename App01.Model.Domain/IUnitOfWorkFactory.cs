namespace App01.Model.Domain
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}