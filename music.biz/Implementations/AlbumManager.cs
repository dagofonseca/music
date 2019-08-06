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
    public class AlbumManager
    {
        private readonly IAlbum dal;

        public AlbumManager(IAlbum implementation)
        {
            dal = implementation;
        }
        public Response<int> Create(Album newObject)
        {
            try
            { 
                if (newObject != null && ValidateName(newObject) && ValidateReleased(newObject))
                {
                    //return dal.Insert(newObject);
                    return new Response<int>(false, "Artist Null or Artist Name isn't valid.", 1000);
                }
                return new Response<int>(false, "Object Null or Album Name or Year release aren't valid.", 1000);
            }
            catch(Exception e)
            {
                return new Response<int>(false, "Something was wrong. Exceptino : " + e.Message,1000);
            }
        }

        public IEnumerable<Album> Show()
        {
            //return dal.SelectAll();
            return null;
        }

        private bool ValidateName(Album ob)
        {
            bool response = !String.IsNullOrWhiteSpace(ob.name);

            return response;
        }

        private bool ValidateReleased(Album ob)
        {
            int currentYear = DateTimeOffset.Now.Year;
            int albumYear = ob.relesed;

            bool response = albumYear <= currentYear;

            return response;
        }
    }

}
