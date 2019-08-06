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
    public class ArtistManager 
    {
        private readonly IArtist dal;

        public ArtistManager(IArtist implementation)
        {
            dal = implementation;
        }

        public Response<int> Create(Artist newObject)
        {
            try
            {
                if (newObject != null && ValidateName(newObject) )
                {
                    //return dal.Insert(newObject);
                    return new Response<int>(false, "Artist Null or Artist Name isn't valid.", 1000);
                }
                return new Response<int>(false, "Artist Null or Artist Name isn't valid.", 1000);
            }
            catch (Exception e)
            {
                return new Response<int>(false, "Something was wrong. Exceptino : " + e.Message,1000);
            }
        }

        public IEnumerable<ArtistDto> Show()
        {
            //return dal.SelectAll();
            return null;
        }

        private bool ValidateName(Artist ob)
        {
            bool response = !String.IsNullOrWhiteSpace(ob.name);

            return response;
        }
    }
}
