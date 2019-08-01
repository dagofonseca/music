using commons;
using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Daos
{
    public class AlbumDao : IAlbum
    {
        public Response Delete(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {
                        Album albumToDelete = db.Album.Find(id);
                        db.Album.Attach(albumToDelete);
                        db.Album.Remove(albumToDelete);
                        db.SaveChanges();
                    }
                    return new Response(true, "Album was delete from DB");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " + e.Message);
                }
            }
            return new Response(false, "Id must be grater than 0");
        }

        public Album FindById(int id)
        {
            Album response;
            using (musicDBEntities db = new musicDBEntities())
            {
                response = db.Album.Find(id);
            }
            return response;
        }

        public Response Insert(Album newObject)
        {
            if (newObject != null)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {
                        db.Album.Add(newObject);
                        db.SaveChanges();
                    }
                    return new Response(true, "Album was inserted in DB");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " + e.Message);
                }
            }
            return new Response(false, "Album cannot be null");
        }

        public IEnumerable<Album> SelectAll()
        {
            using (musicDBEntities db = new musicDBEntities())
            {
                return db.Album.ToList();
            }
        }

        public Response Update(Album updatedObject)
        {
            if (updatedObject != null)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {
                        db.Album.Attach(updatedObject);
                        db.Entry(updatedObject).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return new Response(true, "Album was updated");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " + e.Message);
                }
            }
            return new Response(false, "Album to update cannot be null");
        }
    }
}
