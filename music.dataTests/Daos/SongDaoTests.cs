using commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using music.data.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.data.Daos.Tests
{
    [TestClass()]
    public class SongDaoTests
    {
        [TestMethod()]
        public void FindByIdTest()
        {
            SongDao songDao = new SongDao();
            Song actual = songDao.FindById(2);
            string expected = "bohemio de aficion";

            Assert.AreEqual(expected, actual.title);
        }

        [TestMethod()]
        public void FindByIdThatNoExistTest()
        {
            SongDao songDao = new SongDao();
            Song actual = songDao.FindById(1000);

            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void SelectAllTest()
        {
            SongDao songDao = new SongDao();
            List<Song> actual = songDao.SelectAll().ToList<Song>();
            string expected2 = "bohemio de aficion";
            string expected7 = "las rejas no matan";
            string expected10 = "payaso";

            Assert.AreEqual(expected2, actual[1].title);
            Assert.AreEqual(expected7, actual[6].title);
            Assert.AreEqual(expected10, actual[9].title);
        }

        [TestMethod()]
        public void InsertTest()
        {
            Song newSong = new Song()
            {
                title = "cataclismo",
                genre = "ranchera",
                relesed = 1963,
                fk_album_id = 4,
                fk_artist_id = 2
            };
            SongDao songDao = new SongDao();
            var actual = songDao.Insert(newSong);

            var expected = new Response(true, "Song was inserted in DB");

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void InsertThrowExceptionTest()
        {
            Song newSong = new Song()
            {
                title = null,
                genre = "ranchera",
                relesed = 1963,
                fk_album_id = 4,
                fk_artist_id = 2
            };
            SongDao songDao = new SongDao();
            var actual = songDao.Insert(newSong);

            var expected = new Response(false);

            Assert.AreEqual(expected.Status, actual.Status);
        }

        [TestMethod()]
        public void InsertNullTest()
        {
            Song newSong = null;
            SongDao songDao = new SongDao();
            var actual = songDao.Insert(newSong);

            var expected = new Response(false, "Song cannot be null");

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            SongDao songDao = new SongDao();
            Song song = songDao.SelectAll().First();
            song.title = song.title + " edit";
            var actual = songDao.Update(song);

            var expected = new Response(true, "Song was updated");

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void UpdateNullTest()
        {
            SongDao songDao = new SongDao();
            Song song = null;
            var actual = songDao.Update(song);

            var expected = new Response(false, "Song to update cannot be null");

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void DeleteTest()
        {            
            Song newSong = new Song()
            {
                title = "xxyyzz55",
                genre = "ranchera",
                relesed = 1963,
                fk_album_id = 4,
                fk_artist_id = 2                
            };
            SongDao songDao = new SongDao();
            songDao.Insert(newSong);
            var song = songDao.SelectAll().First(s => s.title == "xxyyzz55");            
            var actual = songDao.Delete(song.song_id);

            var expected = new Response(true, "Song was delete from DB");

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void DeleteIdEqualsToZeroTest()
        {
            SongDao songDao = new SongDao();
            int id = 0;
            var actual = songDao.Delete(id);

            var expected = new Response(false, "Id must be grater than 0");

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void DeleteIdNoExistTest()
        {
            SongDao songDao = new SongDao();
            int id = 10000;
            var actual = songDao.Delete(id);

            var expected = new Response(false);
            Console.WriteLine(actual.Message);

            Assert.AreEqual(expected.Status, actual.Status);            
        }
    }
}