using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Daos
{
    class ArtistDao : IArtist
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Artist FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Artist newObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Artist> SelectAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Artist updatedObject)
        {
            throw new NotImplementedException();
        }
    }
}
