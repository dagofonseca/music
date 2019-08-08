using commons;
using System.Collections.Generic;

namespace music.biz.Interfaces
{
    public interface ISongBiz : IGenericBiz<SongDto>
    {
        Response<IEnumerable<SongDto>> ShowByArtist(int artistId);
        
    }
}
