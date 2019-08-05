using commons;
using music.biz.Implementations;
using music.biz.Interfaces;
using music.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace music.service.Controllers
{
    public class SongController : ApiController
    {
        private readonly ISongBiz bizLogic;
        public SongController(ISongBiz implementation)
        {
            bizLogic = implementation;
        }
        // GET: api/Song
        //public IEnumerable<Song> Get()
        //{
        //    IEnumerable<Song> songs = bizLogic.Show();
        //    //return new JavaScriptSerializer().Serialize(songs);
        //    return songs;
        //}

        public SongDto Get()
        {
            Song song = bizLogic.Show().First();
            SongDto response = new SongDto();

            response.Id = song.song_id;
            response.Title = song.title;
            response.Genre = song.genre;
            response.Released = song.relesed;
            response.AlbumId = song.fk_album_id.GetValueOrDefault();
            response.ArtistId = song.fk_artist_id.GetValueOrDefault();

            return response;
        }

        
        [Route("api/artist/{artistId}/songs")]
        public IEnumerable<SongDto> GetByArtist(int artistId)
        {
            List<Song> songs = bizLogic.ShowByArtist(artistId).ToList();
            List<SongDto> response = new List<SongDto>();
            foreach (Song song in songs)
            {
                SongDto aux = new SongDto();
                aux.Id = song.song_id;
                aux.Title = song.title;
                aux.Released = song.relesed;
                aux.Genre = song.genre;
                response.Add(aux);
            }
            return response;
        }

        // GET: api/Song/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Song
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Song/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Song/5
        public void Delete(int id)
        {
        }
    }
}
