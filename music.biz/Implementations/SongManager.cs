using commons;
using music.biz.Interfaces;
using music.data;
using music.data.Daos;
using music.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.biz.Implementations
{
    public class SongManager : ISongBiz
    {
        private readonly ISong dal;
        private readonly IAlbum dalAlb;
        private readonly IArtist dalArt;

        public SongManager(ISong songDal, IAlbum albumDal, IArtist artistDal)
        {
            dal = songDal;
            dalAlb = albumDal;
            dalArt = artistDal;
        }

        public IEnumerable<Song> Show()
        {
            return dal.SelectAll();
        }

        public IEnumerable<Song> ShowByArtist(int artistId)
        {
            return dal.SelectSongsByArtist(artistId);
        }

        public Response Create(Song newObject)
        {
            Response resp = ValidateSong(newObject);
            if (resp.Status == true)
            {
                return dal.Insert(newObject);
            }
            return resp;
        }


        private Response ValidateSong(Song ob)
        {
            if (ob == null)
                return new Response(false, "Song cannot be null");
            else if (!ValidateAlbum(ob))
                return new Response(false, "Album is not valid");
            else if (!ValidateArtist(ob))
                return new Response(false, "Artist is not valid");
            else if (!ValidateReleased(ob))
                return new Response(false, "Year release must be less than Album's year release");
            else if (!ValidateTitle(ob))
                return new Response(false, "Title cannot be empty");
            else if (!ValidateGenre(ob))
                return new Response(false, "Genre cannot be empty");
            else
                return new Response(true, "Song Valid");
        }
        private bool ValidateTitle(Song ob)
        {
            bool response = !String.IsNullOrWhiteSpace(ob.title);

            return response;
        }
        private bool ValidateGenre(Song ob)
        {
            bool response = !String.IsNullOrWhiteSpace(ob.genre);

            return response;
        }
        private bool ValidateReleased(Song ob)
        {
            int albumId = ob.fk_album_id.GetValueOrDefault();
            Album album = dalAlb.FindById(albumId);
            int albumYear = album.relesed;
            int songYear = ob.relesed;

            return songYear <= albumYear;
        }

        private bool ValidateArtist(Song ob)
        {
            int artistId = ob.fk_artist_id.GetValueOrDefault();
            Artist artist = dalArt.FindById(artistId);

            return artist != null;
        }
        private bool ValidateAlbum(Song ob)
        {
            int albumId = ob.fk_album_id.GetValueOrDefault();
            Album album = dalAlb.FindById(albumId);

            return album != null;
        }                
    }
}
