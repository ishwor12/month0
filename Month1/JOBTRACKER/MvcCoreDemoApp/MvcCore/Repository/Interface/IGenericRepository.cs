namespace MvcCore.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
    //vs if non-generic then
    //public interface IProductRepository
    //{
    // Task <Product?> GetByIdAsync(int id);
    // Task<IEnumerable<Order>> GetAllAsync();
    //  Task <Product?> AddAsync(Peoduct entity);

    //  }

}
