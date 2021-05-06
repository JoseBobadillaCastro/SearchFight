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
    public class GoogleEngineTests
    {
        private GoogleEngine _googleEngine;
        public GoogleEngineTests() 
        {
            _googleEngine = new GoogleEngine();
        }
        [TestMethod]
        public void SimpleQuery()
        {
            Assert.IsInstanceOfType(_googleEngine.searchResultsCount("java"), typeof(Task<int>));
        }
        [TestMethod]
        public void ComplexQuery()
        {
            Assert.IsInstanceOfType(_googleEngine.searchResultsCount("df4t´{+¿'4/sd@ 454f"), typeof(Task<int>));
        }
        [TestMethod]
        public void NullQuery()
        {
            Assert.ThrowsException<ArgumentException>(() => _googleEngine.searchResultsCount(null));
        }
        [TestMethod]
        public void EmptyQuery()
        {
            Assert.ThrowsException<ArgumentException>(() => _googleEngine.searchResultsCount(" "));
        }
    }
}