namespace Data.Repository.Base
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}