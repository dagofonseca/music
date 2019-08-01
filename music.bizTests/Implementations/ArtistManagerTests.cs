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
    public class ArtistManagerTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            ArtistManager artistMng = new ArtistManager();
            Artist artist = new Artist()
            {
                name = "Artista de prueba"
            };

            Response actual = artistMng.Create(artist);
            bool expected = true;

            Console.WriteLine(actual.Message);

            Assert.AreEqual(expected, actual.Status);
        }

        [TestMethod()]
        public void CreateNullTest()
        {
            ArtistManager artistMng = new ArtistManager();
            Artist artist = null;

            Response actual = artistMng.Create(artist);
            bool expected = false;

            Console.WriteLine(actual.Message);
            Assert.AreEqual(expected, actual.Status);

        }

        [TestMethod()]
        public void CreateEmptyNameTest()
        {
            ArtistManager artistMng = new ArtistManager();
            Artist artist = new Artist()
            {
                name = ""
            };

            Response actual = artistMng.Create(artist);
            bool expected = false;

            Console.WriteLine(actual.Message);
            Assert.AreEqual(expected, actual.Status);

        }               
    }
}