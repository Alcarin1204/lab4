using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1.Model;
using WpfApp1.Repositori;

namespace TestingFuskCurs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            Implimentation impliment = new Implimentation();

            Curs bla = impliment.GetCurs().Result;
            Assert.IsNotNull(bla);
        }
    }
}
