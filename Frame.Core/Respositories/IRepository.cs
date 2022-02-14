namespace Frame.Core
{
    public interface IRepository
    {

    }

    public interface IRepository<TEntityPrimary, TEntity>: IRepository
       where TEntity : IEntity
    {

    }
}
