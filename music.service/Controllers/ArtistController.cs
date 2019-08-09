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
    public class ArtistController : ApiController
    {
        private readonly IArtistBiz bizLogic;

        public ArtistController(IArtistBiz implementation)
        {
            bizLogic = implementation;
        }

        // GET: api/Artist
        public Response<IEnumerable<ArtistDto>> Get()
        {
            return bizLogic.Show();            
        }

        // GET: api/Artist/5
        

        public Response<ArtistDto> Get(int id)
        {
            return bizLogic.ShowById(id);
        }

        // POST: api/Artist
        public Response<ArtistDto> Post([FromBody]ArtistDto newObject)
        {
            return bizLogic.Create(newObject);
        }

        // PUT: api/Artist/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Artist/5
        public void Delete(int id)
        {
        }
    }
}
