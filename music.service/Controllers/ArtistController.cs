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
        public IEnumerable<ArtistDto> Get()
        {
            List<Artist> artists = bizLogic.Show().ToList();
            List<ArtistDto> response = new List<ArtistDto>();
            foreach (Artist artist in artists)
            {
                ArtistDto aux = new ArtistDto();
                aux.Id = artist.artist_id;
                aux.Name = artist.name;
                response.Add(aux);
            }
            return response;
        }

        // GET: api/Artist/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Artist
        public void Post([FromBody]string value)
        {
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
