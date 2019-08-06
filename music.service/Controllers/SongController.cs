﻿using commons;
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
