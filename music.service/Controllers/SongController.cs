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
        public Response<IEnumerable<SongDto>> Get()
        {
            return bizLogic.Show();
        }

        [Route("api/artist/{artistId}/songs")]
        public Response<IEnumerable<SongDto>> GetByArtist(int artistId)
        {
            return bizLogic.ShowByArtist(artistId);
        }

        [Route("api/album/{albumId}/songs")]
        public HttpResponseMessage Get(int albumId, int page = 0)
        {
            Response<IEnumerable<SongDto>> songs = bizLogic.GetSongsByAlbum(albumId, page);

            if (!songs.Status)            
                return Request.CreateResponse(HttpStatusCode.BadRequest, songs);

            if (songs.Data.Count() == 0)            
                return Request.CreateResponse(HttpStatusCode.NotFound, songs);

            return Request.CreateResponse(HttpStatusCode.OK, songs);
        }

        // GET: api/Song/5
        public Response<SongDto> Get(int id)
        {
            return bizLogic.ShowById(id);
        }

        // POST: api/Song
        public Response<SongDto> Post([FromBody]SongDto newObject)
        {
            return bizLogic.Create(newObject);
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
