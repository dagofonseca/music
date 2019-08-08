using commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace music.data.Daos.Tests
{
    [TestClass()]
    public class SongDaoTests
    {
        #region FindTests
        [TestMethod()]
        public void FindByIdTest()
        {
            SongDao songDao = new SongDao();
            SongDto responseSong = new SongDto
            {
                Id = 2,
                Title = "bohemio de aficion edit",
                Released = 1998,
                Genre = "ranchera"
            };
            responseSong.SetAlbumId(1);
            responseSong.SetArtistId(1);

            Response<SongDto> expected = new Response<SongDto>(true, "Song was find", responseSong);
            Response<SongDto> actual = songDao.FindById(2);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data.Title, actual.Data.Title);

        }

        [TestMethod()]
        public void FindByIdThatNoExistTest()
        {
            SongDao songDao = new SongDao();

            Response<SongDto> expected = new Response<SongDto>(false, "Somethig was wrong. Exception: ", null);
            Response<SongDto> actual = songDao.FindById(1000);

            bool IsRightMessgage = actual.Message.StartsWith(expected.Message);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Data, actual.Data);
            Assert.AreEqual(true, IsRightMessgage);
        }

        [TestMethod()]
        public void SelectAllTest()
        {
            SongDao songDao = new SongDao();

            String expectedMessage = "23 Songs found";
            String expectedSecondTitle = "me voy a quitar de en medio";
            Response<IEnumerable<SongDto>> actual = songDao.SelectAll();

            Assert.AreEqual(true, actual.Status);
            Assert.AreEqual(expectedMessage, actual.Message);
            Assert.AreEqual(expectedSecondTitle, actual.Data.ElementAt(1).Title);
        }
        #endregion

        #region InsertTests
        [TestMethod()]
        public void InsertTest()
        {
            SongDto newSong = new SongDto()
            {
                Title = "xyz cataclismo xyz",
                Genre = "ranchera",
                Released = 1963
            };
            newSong.SetAlbumId(4);
            newSong.SetArtistId(2);

            SongDao songDao = new SongDao();

            Response<int> expected = new Response<int>(true, "Song was inserted in DB", 0);
            Response<int> actual = songDao.Insert(newSong);

            Console.WriteLine(actual.Data);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreNotEqual(-1, actual.Data);
        }

        [TestMethod()]
        public void InsertThrowExceptionTest()
        {
            SongDto newSong = new SongDto()
            {
                Title = null,
                Genre = "ranchera",
                Released = 1963
            };
            newSong.SetAlbumId(4);
            newSong.SetArtistId(2);
            SongDao songDao = new SongDao();

            Response<int> expected = new Response<int>(false, "Somethig was wrong. Exception: ", -1);
            Response<int> actual = songDao.Insert(newSong);

            bool IsRightMessage = actual.Message.StartsWith(expected.Message);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Data, actual.Data);
            Assert.AreEqual(true, IsRightMessage);
        }

        [TestMethod()]
        public void InsertNullTest()
        {
            SongDto newSong = null;
            SongDao songDao = new SongDao();

            Response<int> expected = new Response<int>(false, "Song cannot be null", -1);
            Response<int> actual = songDao.Insert(newSong);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Data, actual.Data);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        #endregion

        #region UpdateTests

        [TestMethod()]
        public void UpdateTest()
        {
            SongDao songDao = new SongDao();
            SongDto song = songDao.SelectAll().Data.First(s => s.Title == "xyz cataclismo xyz");
            song.Genre = "rock";

            Response<int> expected = new Response<int>(true, "Song was updated", song.Id);
            Response<int> actual = songDao.Update(song);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }

        [TestMethod()]
        public void UpdateNullTest()
        {
            SongDao songDao = new SongDao();
            SongDto song = null;

            var expected = new Response<int>(false, "Song to update cannot be null", -1);
            var actual = songDao.Update(song);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }

        #endregion

        #region DeleteTests

        [TestMethod()]
        public void DeleteTest()
        {
            SongDao songDao = new SongDao();
            SongDto song = songDao.SelectAll().Data.First(s => s.Title == "xyz cataclismo xyz");
            if (song == null)
            {
                song.Title = "xyz cataclismo xyz";
                song.Genre = "ranchera";
                song.Released = 1963;
                song.SetAlbumId(4);
                song.SetArtistId(2);

                int id = songDao.Insert(song).Data;
                song.Id = id;
            }

            Response<int> expected = new Response<int>(true, "Song was delete from DB", song.Id);
            Response<int> actual = songDao.Delete(song.Id);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }

        [TestMethod()]
        public void DeleteIdEqualsToZeroTest()
        {
            SongDao songDao = new SongDao();
            int id = 0;

            Response<int> expected = new Response<int>(false, "Id must be grater than 0", -1);
            Response<int> actual = songDao.Delete(id);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }

        [TestMethod()]
        public void DeleteIdNoExistTest()
        {
            SongDao songDao = new SongDao();
            int id = 10000;

            Response<int> expected = new Response<int>(false, "Somethig was wrong. Exception: ", -1);
            Response<int> actual = songDao.Delete(id);

            bool IsRightMessage = actual.Message.StartsWith(expected.Message);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Data, actual.Data);
            Assert.AreEqual(true, IsRightMessage);
        }

        #endregion
    }
}