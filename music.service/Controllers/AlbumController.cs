using commons;
using music.biz.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace music.service.Controllers
{
    public class AlbumController : ApiController
    {
        readonly IAlbumBiz bizLogic;

        public AlbumController(IAlbumBiz implementation)
        {
            bizLogic = implementation;
        }

        // GET: api/Album
        public Response<IEnumerable<AlbumDto>> Get()
        {
            return bizLogic.Show();            
        }

        // GET: api/Album/5        
        public HttpResponseMessage Get(int id)
        {
            Response<AlbumDto> album = bizLogic.ShowById(id);

            if (album.Status)
                return Request.CreateResponse(HttpStatusCode.OK, album);

            return Request.CreateResponse(HttpStatusCode.NotFound, album);
        }

        // POST: api/Album
        public Response<AlbumDto> Post([FromBody]AlbumDto newObject)
        {
            return bizLogic.Create(newObject);
        }

        // PUT: api/Album/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Album/5
        public void Delete(int id)
        {
        }
    }
}
