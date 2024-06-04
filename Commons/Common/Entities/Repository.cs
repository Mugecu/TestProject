namespace Common.Entities
{
    public abstract class Repository<T> where T : AggregateRoot
    {
        public abstract Task<T> CreateAsync(T root);
        public abstract Task<T?> GetAsync(Guid id);
        public abstract Task SaveAsync();
    }
}
