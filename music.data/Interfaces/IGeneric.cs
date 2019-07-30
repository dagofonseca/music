using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Interfaces
{
    interface IGeneric<T>
    {
        bool Insert(T newObject);
        bool Delete(int id);
        bool Update(T updatedObject);
        T FindById(int id);
        IQueryable<T> SelectAll();
    }
}
