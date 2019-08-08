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
        public Response<int> Delete(int id)
        {
            if (id <= 0)
                return new Response<int>(false, "Id must be grater than 0", -1);

            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    Song songToDelete = db.Song.Find(id);
                    db.Song.Attach(songToDelete);
                    id = db.Song.Remove(songToDelete).song_id;
                    db.SaveChanges();
                }
                return new Response<int>(true, "Song was delete from DB", id);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.Message, -1);
                else
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, -1);
            }

        }

        public Response<SongDto> FindById(int id)
        {
            if (id <= 0)
                return new Response<SongDto>(false, "Id must be grater than 0", null);

            SongDto response = new SongDto();
            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    Song song = db.Song.Find(id);
                    response.Id = song.song_id;
                    response.Title = song.title;
                    response.Released = song.relesed;
                    response.SetAlbumId(song.fk_album_id);
                    response.SetArtistId(song.fk_artist_id);
                }
                return new Response<SongDto>(true, "Song was find", response);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<SongDto>(false, "Somethig was wrong. Exception: " + e.Message, null);
                else
                    return new Response<SongDto>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, null);
            }
        }

        public Response<int> Insert(SongDto newObject)
        {
            if (newObject == null)
                return new Response<int>(false, "Song cannot be null", -1);

            Song song = new Song
            {
                title = newObject.Title,
                genre = newObject.Genre,
                relesed = newObject.Released,
                fk_album_id = newObject.AlbumId,
                fk_artist_id = newObject.ArtistId
            };

            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    db.Song.Add(song);
                    db.SaveChanges();
                }
                return new Response<int>(true, "Song was inserted in DB", song.song_id);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.Message, -1);
                else
                    return new Response<int>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, -1);
            }
        }

        public Response<IEnumerable<SongDto>> SelectAll()
        {
            List<SongDto> response = new List<SongDto>();
            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    List<Song> songs = db.Song.ToList();

                    foreach (Song song in songs)
                    {
                        SongDto aux = new SongDto
                        {
                            Id = song.song_id,
                            Title = song.title,
                            Genre = song.genre,
                            Released = song.relesed
                        };
                        aux.SetAlbumId(song.fk_album_id);
                        aux.SetArtistId(song.fk_artist_id);

                        response.Add(aux);
                    }
                }
                return new Response<IEnumerable<SongDto>>(true, response.Count + " Songs found", response);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<IEnumerable<SongDto>>(false, "Somethig was wrong. Exception: " + e.Message, response);
                else
                    return new Response<IEnumerable<SongDto>>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, response);

            }
        }

        public Response<IEnumerable<SongDto>> SelectSongsByArtist(int artistId)
        {
            if (artistId <= 0)
                return new Response<IEnumerable<SongDto>>(false, "Id must be greater than 0", null);

            List<SongDto> response = new List<SongDto>();
            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    List<Song> songs = db.Song.Where(s => s.fk_artist_id == artistId).ToList();

                    foreach (Song song in songs)
                    {
                        SongDto aux = new SongDto
                        {
                            Id = song.song_id,
                            Title = song.title,
                            Genre = song.genre,
                            Released = song.relesed
                        };
                        aux.SetAlbumId(song.fk_album_id);
                        aux.SetArtistId(song.fk_artist_id);

                        response.Add(aux);
                    }
                }
                return new Response<IEnumerable<SongDto>>(true, response.Count + " Songs found", response);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<IEnumerable<SongDto>>(false, "Somethig was wrong. Exception: " + e.Message, response);
                else
                    return new Response<IEnumerable<SongDto>>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, response);

            }
        }

        public Response<int> Update(SongDto updatedObject)
        {
            if (updatedObject == null)
                return new Response<int>(false, "Song to update cannot be null", -1);

            try
            {
                using (musicDBEntities db = new musicDBEntities())
                {
                    Song songToUpdate = db.Song.Find(updatedObject.Id);

                    if (songToUpdate == null)
                        return new Response<int>(false, "Song to update isn't in the database", -1);

                    songToUpdate.title = updatedObject.Title;
                    songToUpdate.genre = updatedObject.Genre;
                    songToUpdate.relesed = updatedObject.Released;
                    songToUpdate.fk_album_id = updatedObject.AlbumId;
                    songToUpdate.fk_artist_id = updatedObject.ArtistId;
                    
                    db.Song.Attach(songToUpdate);
                    db.Entry(songToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return new Response<int>(true, "Song was updated", updatedObject.Id);
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
