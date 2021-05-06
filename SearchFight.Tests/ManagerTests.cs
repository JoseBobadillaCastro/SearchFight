using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.Core;
using SearchFight.Infraestructure;
using System.Threading.Tasks;
namespace SearchFight.Tests
{
    [TestClass]
    public class ManagerTests
    {
        private Manager _manager;
        public ManagerTests()
        {
            _manager = Factory.createManager();
        }
        [TestMethod]
        public void SimpleQuery()
        {
            List<string> query = new List<string> {"peru","brasil"};
            Assert.IsInstanceOfType(_manager.loadResults(query), typeof(Task<string>));
        }
        [TestMethod]
        public void ComplexQuery()
        {
            List<string> query = new List<string> { "df4t´{+¿'4/sd@ 454f", "u8y&39ee*33!" };
            Assert.ThrowsException<NullReferenceException>(() => _manager.loadResults(query));
        }
    }
}
