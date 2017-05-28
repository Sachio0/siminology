using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spCenter.DataBase;

namespace spCenterTest.Database
{
    [TestClass]
    public class DatabaseConnectingTest
    {
        [TestMethod]
        public void StartTest()
        {
            DatabaseConnecting dc = new DatabaseConnecting();
            dc.start();
        }
    }
}
