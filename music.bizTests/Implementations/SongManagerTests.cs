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

            Album album = albumDao.SelectAll().First();
            Artist artist = artistDao.SelectAll().First();

            Song song = new Song()
            {
                title = "Canción de prueba",
                genre = "genero de prueba",
                fk_album_id = album.album_id,
                fk_artist_id = artist.artist_id
            };

            var actual = songMng.Create(song);
            var expected = true;

            Console.WriteLine(actual.Message);
            Assert.AreEqual(expected, actual.Status);
        }

        [TestMethod()]
        public void ShowTest()
        {
            SongManager songMng = new SongManager();

            int actual = songMng.Show().Count();
            int expected = 23;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShowFirstTest()
        {
            SongManager songMng = new SongManager();

            string actual = songMng.Show().First().title;
            string expected = "bohemio de aficion edit";

            Assert.AreEqual(expected, actual);
        }
    }
}