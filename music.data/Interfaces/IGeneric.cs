using commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Interfaces
{
    interface IGeneric<T>
    {
        Response Insert(T newObject);
        Response Delete(int id);
        Response Update(T updatedObject);
        T FindById(int id);
        IEnumerable<T> SelectAll();
    }
}
