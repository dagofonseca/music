using commons;
using music.biz.Interfaces;
using music.data.Interfaces;
using System;
using System.Collections.Generic;

namespace music.biz.Implementations
{
    public class AlbumManager : IAlbumBiz
    {
        private readonly IAlbum dal;

        public AlbumManager(IAlbum implementation)
        {
            dal = implementation;
        }
        public Response<AlbumDto> Create(AlbumDto newObject)
        {
            try
            { 
                if (newObject != null && ValidateName(newObject) && ValidateReleased(newObject))
                {
                    Response<int> dataResponse = dal.Insert(newObject);
                    newObject.Id = dataResponse.Data;
                    return new Response<AlbumDto>(dataResponse.Status, dataResponse.Message, newObject);
                }
                return new Response<AlbumDto>(false, "Object Null or Album Name or Year release aren't valid.", null);
            }
            catch(Exception e)
            {
                if (e.InnerException == null)
                    return new Response<AlbumDto>(false, "Somethig was wrong. Exception: " + e.Message, null);
                else
                    return new Response<AlbumDto>(false, "Somethig was wrong. Exception: " + e.InnerException.InnerException.Message, null);
            }
        }

        public Response<IEnumerable<AlbumDto>> Show()
        {
            return dal.SelectAll();            
        }

        public Response<AlbumDto> ShowById(int id)
        {
            return dal.FindById(id);
        }

        private bool ValidateName(AlbumDto album)
        {
            bool response = !String.IsNullOrWhiteSpace(album.Name);

            return response;
        }

        private bool ValidateReleased(AlbumDto album)
        {
            int currentYear = DateTimeOffset.Now.Year;
            int albumYear = album.Released;

            bool response = albumYear <= currentYear;

            return response;
        }
    }

}
