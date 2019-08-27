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

        public Response<IEnumerable<SongDto>> Show()
        {
            return dal.SelectAll();
        }

        public Response<IEnumerable<SongDto>> ShowByArtist(int artistId)
        {
            return dal.SelectSongsByArtist(artistId);
        }

        /// <summary>
        /// gets songs of a specific album
        /// </summary>
        /// <param name="albumId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Response<IEnumerable<SongDto>> GetSongsByAlbum(int albumId, int page = 0)
        {
            return dal.SelectSongsByAlbum(albumId, page);
        }

        public Response<SongDto> Create(SongDto newObject)
        {
            Response<SongDto> resp = ValidateSong(newObject);
            if (resp.Status == true)
            {
                Response<int> dataResponse = dal.Insert(newObject);
                newObject.Id = dataResponse.Data;
                return new Response<SongDto>(dataResponse.Status, dataResponse.Message, newObject);
            }
            return resp;
        }

        public Response<SongDto> ShowById(int id)
        {
            return dal.FindById(id);
        }

        private Response<SongDto> ValidateSong(SongDto song)
        {
            if (song == null)
                return new Response<SongDto>(false, "Song cannot be null", null);
            else if (!ValidateAlbum(song))
                return new Response<SongDto>(false, "Album is not valid",null);
            else if (!ValidateArtist(song))
                return new Response<SongDto>(false, "Artist is not valid", null);
            else if (!ValidateReleased(song))
                return new Response<SongDto>(false, "Year release must be less than Album's year release", null);
            else if (!ValidateTitle(song))
                return new Response<SongDto>(false, "Title cannot be empty",null);
            else if (!ValidateGenre(song))
                return new Response<SongDto>(false, "Genre cannot be empty",null);
            else
                return new Response<SongDto>(true, "Song Valid", song);
        }
        private bool ValidateTitle(SongDto song)
        {
            bool response = !String.IsNullOrWhiteSpace(song.Title);

            return response;
        }
        private bool ValidateGenre(SongDto song)
        {
            bool response = !String.IsNullOrWhiteSpace(song.Genre);

            return response;
        }
        private bool ValidateReleased(SongDto song)
        {            
            AlbumDto album = dalAlb.FindById(song.AlbumId).Data;
            int albumYear = album.Released;
            int songYear = song.Released;

            return songYear <= albumYear;
        }

        private bool ValidateArtist(SongDto song)
        {
            ArtistDto artist = dalArt.FindById(song.ArtistId).Data;

            return artist != null;
        }
        private bool ValidateAlbum(SongDto song)
        {
            AlbumDto album = dalAlb.FindById(song.AlbumId).Data;

            return album != null;
        }                
    }
}
