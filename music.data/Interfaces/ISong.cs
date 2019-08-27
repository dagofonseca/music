using commons;
using System.Collections.Generic;

namespace music.data.Interfaces
{
    public interface ISong : IGeneric<SongDto>
    {
        Response<IEnumerable<SongDto>> SelectSongsByArtist(int artistId);
        Response<IEnumerable<SongDto>> SelectSongsByAlbum(int albumId, int page);
    }
}
