﻿using music.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.biz.Interfaces
{
    public interface ISongBiz : IGenericBiz<Song>
    {
        IEnumerable<Song> ShowByArtist(int artistId);
    }
}
