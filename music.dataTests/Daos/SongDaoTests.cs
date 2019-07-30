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
        public void SelectAllTest()
        {
            SongDao songDao = new SongDao();
            List<Song> actual = songDao.SelectAll2().ToList<Song>();
            string expected2 = "bohemio de aficion";
            string expected7 = "las rejas no matan";
            string expected10 = "payaso";

            Assert.AreEqual(expected2, actual[1].title);
            Assert.AreEqual(expected7, actual[6].title);
            Assert.AreEqual(expected10, actual[9].title);
        }
    }
}