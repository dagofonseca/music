using commons;
using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace music.data.Daos
{
    public class AlbumDao : IAlbum
    {
        public Response<int> Delete(int id)
        {
            if (id <= 0)
                return new Response<int>(false, "Id must be grater than 0", -1);

            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    Album albumToDelete = db.Album.Find(id);
                    db.Album.Attach(albumToDelete);
                    id = db.Album.Remove(albumToDelete).album_id;
                    db.SaveChanges();
                }
                return new Response<int>(true, "Album was delete from DB", id);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.Message, -1);
                else
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, -1);
            }
        }

        public Response<AlbumDto> FindById(int id)
        {
            if (id <= 0)
                return new Response<AlbumDto>(false, "Id must be grater than 0", null);

            AlbumDto response = new AlbumDto();
            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    Album album = db.Album.Find(id);
                    response.Id = album.album_id;
                    response.Name = album.name;
                    response.Released = album.relesed;
                }
                return new Response<AlbumDto>(true, "Element was found", response);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<AlbumDto>(false, "Somethig was wrong. Exception: " + e.Message, null);
                else
                    return new Response<AlbumDto>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, null);
            }

        }

        public Response<int> Insert(AlbumDto newObject)
        {
            if (newObject == null)
                return new Response<int>(false, "Album cannot be null", -1);

            Album album = new Album();
            album.name = newObject.Name;
            album.relesed = newObject.Released;

            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    db.Album.Add(album);
                    db.SaveChanges();
                }
                return new Response<int>(true, "Album was inserted in DB", album.album_id);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.Message, -1);
                else
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, -1);
            }


        }

        public Response<IEnumerable<AlbumDto>> SelectAll()
        {
            using (musicDBEntities db = new musicDBEntities())
            {
                return db.Album.ToList();
            }
        }

        public Response<int> Update(AlbumDto updatedObject)
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
