using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commons
{    
    public class SongDto
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Released { get; set; }
        public int AlbumId { get; private set; }
        public int ArtistId { get; private set; }
        #endregion        

        public void SetAlbumId(int? value)
        {
            AlbumId = value.GetValueOrDefault();
        }

        public void SetArtistId(int? value)
        {
            ArtistId = value.GetValueOrDefault();
        }
    }
}
