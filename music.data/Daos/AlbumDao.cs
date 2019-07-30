using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Daos
{
    class AlbumDao : IAlbum
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Album FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Album newObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Album> SelectAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Album updatedObject)
        {
            throw new NotImplementedException();
        }
    }
}
