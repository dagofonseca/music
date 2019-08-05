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
        public IEnumerable<AlbumDto> Get()
        {
            List<Album> albums = bizLogic.Show().ToList();
            List<AlbumDto> response = new List<AlbumDto>();
            foreach (Album album in albums)
            {
                AlbumDto aux = new AlbumDto();
                aux.Id = album.album_id;
                aux.Name = album.name;
                aux.Released = album.relesed;

                response.Add(aux);
            }
            return response;
        }

        // GET: api/Album/5
        public string Get(int id)
        {
            return "value";
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
