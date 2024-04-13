namespace EstudoBDM.Infraestructure
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        IRepository<T> Repository<T>() where T : class;
    }
    public class UnitOfWork
    {

    }
}
