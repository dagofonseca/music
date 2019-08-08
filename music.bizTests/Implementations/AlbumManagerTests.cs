using commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using music.biz.Implementations;
using music.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music.biz.Implementations.Tests
{
    [TestClass()]
    public class AlbumManagerTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            AlbumManager albumMng = new AlbumManager();
            Album album = new Album()
            {
                name = "Album de prueba",
                relesed = 1990
            };

            Response actual = albumMng.Create(album);
            bool expected = true;

            Console.WriteLine(actual.Message);

            Assert.AreEqual(expected, actual.Status);
        }
        [TestMethod()]
        public void CreateNullTest()
        {
            AlbumManager albumMng = new AlbumManager();
            Album album = null;

            Response actual = albumMng.Create(album);
            bool expected = false;

            Console.WriteLine(actual.Message);

            Assert.AreEqual(expected, actual.Status);
        }

        [TestMethod()]
        public void CreateEmptyNameTest()
        {
            AlbumManager albumMng = new AlbumManager();
            Album album = new Album()
            {
                name = "",
                relesed = 1990
            };

            Response actual = albumMng.Create(album);
            bool expected = false;

            Console.WriteLine(actual.Message);

            Assert.AreEqual(expected, actual.Status);
        }

        [TestMethod()]
        public void CreateRelesedViolationTest()
        {
            AlbumManager albumMng = new AlbumManager();
            Album album = new Album()
            {
                name = "Relesed Violation",
                relesed = 2022
            };

            Response actual = albumMng.Create(album);
            bool expected = false;

            Console.WriteLine(actual.Message);

            Assert.AreEqual(expected, actual.Status);
        }
    }
}