using commons;
using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Daos
{
    public class ArtistDao : IArtist
    {
        public Response Delete(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {
                        Artist artistToDelete = db.Artist.Find(id);
                        db.Artist.Attach(artistToDelete);
                        db.Artist.Remove(artistToDelete);
                        db.SaveChanges();
                    }
                    return new Response(true, "Artist was delete from DB");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " + e.Message);
                }
            }
            return new Response(false, "Id must be grater than 0");
        }

        public Artist FindById(int id)
        {
            Artist response;
            using (musicDBEntities db = new musicDBEntities())
            {
                response = db.Artist.Find(id);
            }
            return response;
        }

        public Response Insert(Artist newObject)
        {
            if (newObject != null)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {
                        db.Artist.Add(newObject);
                        db.SaveChanges();
                    }
                    return new Response(true, "Artist was inserted in DB");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " + e.Message);
                }
            }
            return new Response(false, "Artist cannot be null");
        }

        public IEnumerable<Artist> SelectAll()
        {
            using (musicDBEntities db = new musicDBEntities())
            {
                return db.Artist.ToList();
            }
        }

        public Response Update(Artist updatedObject)
        {
            if (updatedObject != null)
            {
                try
                {
                    using (musicDBEntities db = new musicDBEntities())
                    {
                        db.Artist.Attach(updatedObject);
                        db.Entry(updatedObject).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return new Response(true, "Artist was updated");
                }
                catch (Exception e)
                {
                    return new Response(false, "Somethig was wrong. Exception: " + e.Message);
                }
            }
            return new Response(false, "Artist to update cannot be null");
        }
    }
}
