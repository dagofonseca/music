using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Daos
{
    public class SongDao : IGeneric<Song>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Song FindById(int id)
        {
            Song response;
            using (musicDBEntities db = new musicDBEntities())
            {
                response = db.Song.Find(id);
            }
            return response;
        }

        public bool Insert(Song newObject)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Song> SelectAll()
        {            
            using (musicDBEntities db = new musicDBEntities())
            {
                return db.Song;
            }            
        }

        public bool Update(Song updatedObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> SelectAll2()
        {
            using (musicDBEntities db = new musicDBEntities())
            {
                return db.Song.ToList();
            }
        }
    }
}
