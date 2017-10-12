namespace AtomicArcade.Repositories
{
    public interface IAAPortalUnitOfWork
    {
        T GetRepository<T>() where T : class;
    }
}