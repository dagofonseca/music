using Microsoft.VisualStudio.TestTools.UnitTesting;
using music.biz.Implementations;
using music.data;
using music.data.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.biz.Implementations.Tests
{
    [TestClass()]
    public class SongManagerTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            SongManager songMng = new SongManager();
            AlbumDao albumDao = new AlbumDao();
            ArtistDao artistDao = new ArtistDao();

            
            Song song = new Song()
            {
                title = "Canción de prueba",
                genre = "genero de prueba"                
            };
        }
    }
}