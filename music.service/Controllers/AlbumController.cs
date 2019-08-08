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
        public void Post([FromBody]string value)
        {
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
