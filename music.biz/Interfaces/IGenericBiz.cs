using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.biz.Interfaces
{
    interface IGenericBiz<T>
    {
        ICollection<T> filterByName(string name);
    }
}
