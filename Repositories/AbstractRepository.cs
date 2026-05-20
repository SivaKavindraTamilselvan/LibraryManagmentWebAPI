using LibraryManagement.Interfaces;
using LibraryManagement.DataAccessLibrary.DBContext;

namespace LibraryManagement.Repositories;

// usage of linq

public abstract class AbstractRepository<K, T> : IRepository<K, T> where T : class where K : notnull
{
    protected readonly LibraryManagementContext libraryManagementContext;
    public AbstractRepository()
    {
        libraryManagementContext = new LibraryManagementContext();
    }
    public abstract T? Get(K key);

    // Get the details of the tables by id
    public T Create(T item)
    {

        libraryManagementContext.Add(item);
        libraryManagementContext.SaveChanges();
        return item;
    }

    // get all details of a table
    public List<T> GetAll()
    {
        return libraryManagementContext.Set<T>().ToList();
    }

    // update the table by primary key id

    public T? Update(K key,T item)
    {
        var items = Get(key);
        if(items == null)
        {
            return null;
        }
        libraryManagementContext.Update(item);
        libraryManagementContext.SaveChanges();
        return items;
    }
}