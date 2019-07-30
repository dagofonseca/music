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
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Users FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Users newObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Users> SelectAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Users updatedObject)
        {
            throw new NotImplementedException();
        }
    }
}
