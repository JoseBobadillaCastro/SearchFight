using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchFight.Services;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
>>>>>>> 637b5dbd39f8ee2c42877a7654d9ec86bed51439
namespace SearchFight.Tests
{
    [TestClass]
    public class BingEngineTests
    {
        private BingEngine _bingEngine;
        public BingEngineTests()
        {
            _bingEngine = new BingEngine();
        }
        [TestMethod]
        public void SimpleQuery()
        {
            Assert.IsInstanceOfType(_bingEngine.searchResultsCount("java"), typeof(Task<int>));
        }
        [TestMethod]
        public void ComplexQuery()
        {
            Assert.ThrowsException<NullReferenceException>(() => _bingEngine.searchResultsCount("df4t´{+¿'4/sd@ 454f"));
        }
        [TestMethod]
        public void NullQuery()
        {
            Assert.ThrowsException<ArgumentException>(() => _bingEngine.searchResultsCount(null));
        }
        [TestMethod]
        public void EmptyQuery()
        {
            Assert.ThrowsException<ArgumentException>(() => _bingEngine.searchResultsCount(" "));
        }
    }
}