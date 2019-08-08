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
    public class AlbumDaoTests
    {
        #region InsertTests
        [TestMethod()]
        public void InsertTest()
        {
            AlbumDto albumToInsert = new AlbumDto()
            {
                Name = "xyz album de prueba",
                Released = 2019
            };
            AlbumDao dal = new AlbumDao();

            Response<int> expected = new Response<int>(true, "Album was inserted in DB", 0);
            Response<int> actual = dal.Insert(albumToInsert);

            Console.WriteLine(actual.Data);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreNotEqual(-1, actual.Data);
        }

        [TestMethod()]
        public void InsertNullAlbumTest()
        {
            AlbumDto albumToInsert = null;
            AlbumDao dal = new AlbumDao();

            Response<int> expected = new Response<int>(false, "Album cannot be null", -1);
            Response<int> actual = dal.Insert(albumToInsert);
            
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }

        [TestMethod()]
        public void InsertAlbumWithNullNameTest()
        {
            AlbumDto albumToInsert = new AlbumDto()
            {
                Name = null,
                Released = 2019
            };
            AlbumDao dal = new AlbumDao();

            Response<int> expected = new Response<int>(false, "Somethig was wrong. Exception: ", -1);
            Response<int> actual = dal.Insert(albumToInsert);

            bool IsRightMessage = actual.Message.StartsWith(actual.Message);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Data, actual.Data);
            Assert.AreEqual(true, IsRightMessage);
        }
        #endregion

        #region UpdateTest
        [TestMethod()]
        public void UpdateTest()
        {
            AlbumDao dal = new AlbumDao();
            AlbumDto album = dal.SelectAll().Data.First(e => e.Name == "xyz album de prueba");
            album.Released = 2000;

            Response<int> expected = new Response<int>(true, "Album was updated", album.Id);
            Response<int> actual = dal.Update(album);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }
        [TestMethod()]
        public void UpdateNullAlbumTest()
        {
            AlbumDao dal = new AlbumDao();
            AlbumDto album = null;

            Response<int> expected = new Response<int>(false, "Album to update cannot be null", -1);
            Response<int> actual = dal.Update(album);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }

        [TestMethod()]
        public void UpdateAlbumThatIsNotInTheDatabaseTest()
        {
            AlbumDao dal = new AlbumDao();
            AlbumDto album = new AlbumDto()
            {
                Id = 8000,
                Name = "No existe",
                Released = 1900
            };

            Response<int> expected = new Response<int>(false, "Album to update isn't in the database", -1);
            Response<int> actual = dal.Update(album);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }
        #endregion

        #region DeleteTest
        [TestMethod()]
        public void DeleteTest()
        {
            AlbumDao dal = new AlbumDao();
            AlbumDto album = dal.SelectAll().Data.First(e => e.Name == "xyz album de prueba");

            Response<int> expected = new Response<int>(true, "Album was delete from DB", album.Id);
            Response<int> actual = dal.Delete(album.Id);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }

        [TestMethod()]
        public void DeleteAlbumIdEqualZeroTest()
        {
            AlbumDao dal = new AlbumDao();            

            Response<int> expected = new Response<int>(false, "Id must be grater than 0", -1);
            Response<int> actual = dal.Delete(0);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);
        }

        [TestMethod()]
        public void DeleteAlbumIdIsNotInTheDatabaseTest()
        {
            AlbumDao dal = new AlbumDao();

            Response<int> expected = new Response<int>(false, "Somethig was wrong. Exception: " , -1);
            Response<int> actual = dal.Delete(300000);

            bool IsRightMessage = actual.Message.StartsWith(expected.Message);

            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Data, actual.Data);
            Assert.AreEqual(true, IsRightMessage);
        }
        #endregion

    }
}