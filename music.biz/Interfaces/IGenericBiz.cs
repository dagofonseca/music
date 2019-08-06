using commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.biz.Interfaces
{
    public interface IGenericBiz<T>
    {
        Response<T> Create (T newObject);
        IEnumerable<T> Show();
    }
}
