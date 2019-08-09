using commons;
using music.biz.Interfaces;
using System.Collections.Generic;
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
        public Response<AlbumDto> Get(int id)
        {
            return bizLogic.ShowById(id);
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
