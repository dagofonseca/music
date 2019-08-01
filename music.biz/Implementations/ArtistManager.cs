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
    public class ArtistManager : IArtistBiz
    {
        readonly IArtist dal = new ArtistDao();
        public Response Create(Artist newObject)
        {
            try
            {
                if (newObject != null && ValidateName(newObject) )
                {
                    return dal.Insert(newObject);
                }
                return new Response(false, "Artist Null or Artist Name isn't valid.");
            }
            catch (Exception e)
            {
                return new Response(false, "Something was wrong. Exceptino : " + e.Message);
            }
        }
        private bool ValidateName(Artist ob)
        {
            bool response = !String.IsNullOrWhiteSpace(ob.name);

            return response;
        }
    }
}
