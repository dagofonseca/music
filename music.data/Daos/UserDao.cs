using commons;
using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Daos
{
    class UserDao : IUser
    {
        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Users FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Response Insert(Users newObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Response Update(Users updatedObject)
        {
            throw new NotImplementedException();
        }
    }
}
