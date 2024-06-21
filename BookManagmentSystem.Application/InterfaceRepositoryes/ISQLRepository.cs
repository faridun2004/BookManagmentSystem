using BookManagmentSystem.Domain.Entities;


namespace BookManagmentSystem.Application.InterfaceRepositories
{
    public interface ISQLRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(Guid id);
        T TryCreate(T item, out string message);
        bool TryUpdate(T item, out string message);
        bool TryDelete(Guid id, out string message);
    }
}
