using commons;
using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Daos
{
    public class SongDao : ISong
    {
        public Response Delete(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {
                        Song songToDelete = db.Song.Find(id);
                        db.Song.Attach(songToDelete);
                        db.Song.Remove(songToDelete);
                        db.SaveChanges();
                    }
                    return new Response(true, "Song was delete from DB");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " + e.Message);
                }
            }
            return new Response(false, "Id must be grater than 0");
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

        public Response Insert(Song newObject)
        {
            if (newObject != null)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {
                        db.Song.Add(newObject);
                        db.SaveChanges();
                    }
                    return new Response(true, "Song was inserted in DB");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " +  e.Message);
                }
            }
            return new Response(false, "Song cannot be null");
        }

        public IEnumerable<Song> SelectAll()
        {
            using (musicDBEntities db = new musicDBEntities())
            {
                return db.Song.ToList();
            }
        }

        public Response Update(Song updatedObject)
        {
            if (updatedObject != null)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {                        
                        db.Song.Attach(updatedObject);
                        db.Entry(updatedObject).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return new Response(true, "Song was updated");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " + e.Message);
                }
            }
            return new Response(false, "Song to update cannot be null");
        }
    }
}
