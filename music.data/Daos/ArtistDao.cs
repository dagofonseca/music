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
        public Response<int> Delete(int id)
        {
            if (id <= 0)
                return new Response<int>(false, "Id must be grater than 0", -1);

            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    Artist artistToDelete = db.Artist.Find(id);
                    db.Artist.Attach(artistToDelete);
                    id = db.Artist.Remove(artistToDelete).artist_id;
                    db.SaveChanges();
                }
                return new Response<int>(true, "Artist was delete from DB", id);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.Message, -1);
                else
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, -1);
            }

        }

        public Response<ArtistDto> FindById(int id)
        {
            if (id <= 0)
                return new Response<ArtistDto>(false, "Id must be grater than 0", null);
            try
            {

                ArtistDto response = new ArtistDto();
                using (musicDBEntities db = new musicDBEntities())
                {
                    Artist artist = db.Artist.Find(id);
                    response.Id = artist.artist_id;
                    response.Name = artist.name;
                }
                return new Response<ArtistDto>(true, "Artist was found", response);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<ArtistDto>(false, "Somethig was wrong. Exception: " + e.Message, null);
                else
                    return new Response<ArtistDto>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, null);
            }
        }

        public Response<int> Insert(ArtistDto newObject)
        {
            if (newObject != null)
                return new Response<int>(false, "Artist cannot be null", 1000);

            Artist artist = new Artist();
            artist.name = newObject.Name;

            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    db.Artist.Add(artist);
                    db.SaveChanges();
                }
                return new Response<int>(true, "Artist was inserted in DB", artist.artist_id);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.Message, -1);
                else
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, -1);
            }

        }

        public Response<IEnumerable<ArtistDto>> SelectAll()
        {

            List<ArtistDto> response = new List<ArtistDto>();
            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    List<Artist> artists = db.Artist.ToList();

                    foreach (Artist artist in artists)
                    {
                        ArtistDto aux = new ArtistDto();
                        aux.Id = artist.artist_id;
                        aux.Name = artist.name;
                        response.Add(aux);
                    }
                }
                return new Response<IEnumerable<ArtistDto>>(true, response.Count + " albums found", response);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<IEnumerable<ArtistDto>>(false, "Somethig was wrong. Exception: " + e.Message, response);
                else
                    return new Response<IEnumerable<ArtistDto>>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, response);
            }

        }

        public Response<int> Update(ArtistDto updatedObject)
        {
            if (updatedObject == null)
                return new Response<int>(false, "Artist to update cannot be null", -1);

            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    Artist artistToUpdate = db.Artist.Find(updatedObject.Id);

                    if (artistToUpdate == null)
                        return new Response<int>(false, "Artist to update isn't in the database", -1);

                    artistToUpdate.name = updatedObject.Name;

                    db.Artist.Attach(artistToUpdate);
                    db.Entry(artistToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return new Response<int>(true, "Artist was updated", updatedObject.Id);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.Message, -1);
                else
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, -1);
            }

        }
    }
}
