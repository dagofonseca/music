using commons;
using music.biz.Interfaces;
using music.data.Interfaces;
using System;
using System.Collections.Generic;

namespace music.biz.Implementations
{
    public class ArtistManager : IArtistBiz
    {
        private readonly IArtist dal;

        public ArtistManager(IArtist implementation)
        {
            dal = implementation;
        }

        public Response<ArtistDto> Create(ArtistDto newObject)
        {
            try
            {
                if (newObject != null && ValidateName(newObject) )
                {
                    Response<int> dataResponse = dal.Insert(newObject);
                    newObject.Id = dataResponse.Data;

                    return new Response<ArtistDto>(dataResponse.Status, dataResponse.Message, newObject);
                }
                return new Response<ArtistDto>(false, "Artist Null or Artist Name isn't valid.", null);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    return new Response<ArtistDto>(false, "Somethig was wrong. Exception: " + e.Message, null);
                else
                    return new Response<ArtistDto>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, null);
            }
        }

        public Response<ArtistDto> ShowById(int id)
        {
            return dal.FindById(id);
        }

        public Response<IEnumerable<ArtistDto>> Show()
        {
            return dal.SelectAll();
        }

        private bool ValidateName(ArtistDto artist)
        {
            bool response = !String.IsNullOrWhiteSpace(artist.Name);

            return response;
        }
    }
}
