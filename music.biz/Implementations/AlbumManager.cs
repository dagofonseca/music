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
    public class AlbumManager : IAlbumBiz
    {
        readonly IAlbum dal = new AlbumDao();
        public Response Create(Album newObject)
        {
            try
            { 
                if (newObject != null && ValidateName(newObject) && ValidateReleased(newObject))
                {
                    return dal.Insert(newObject);
                }
                return new Response(false, "Object Null or Album Name or Year release aren't valid.");
            }
            catch(Exception e)
            {
                return new Response(false, "Something was wrong. Exceptino : " + e.Message);
            }
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
