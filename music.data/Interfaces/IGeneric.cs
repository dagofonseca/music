using commons;
using System.Collections.Generic;

namespace music.data.Interfaces
{
    public interface IGeneric<T>
    {
        Response<int> Insert(T newObject);
        Response<int> Delete(int id);
        Response<int> Update(T updatedObject);
        Response<T> FindById(int id);
        Response<IEnumerable<T>> SelectAll();
    }
}
