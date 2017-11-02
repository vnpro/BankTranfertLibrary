using BankTranfertLibrary;
using BankTransfertLibrarySolid;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTransfertLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        #region TestsBankTransfertLibrary
        [TestMethod]
        public void TestMethod1()
        {
            var bankTransfert = new BankTransfert();
            bankTransfert.Transfert(1, 12.2m, "4514561", "8546129856");
        }
        #endregion

        // Tests solid
        #region TestsBankTransfertLibrarySolid

        // Test de base
        [TestMethod]
        public void TestMethod2()
        {
            var bankTransfert = new BankTransfertSolid();
            bankTransfert.Transfert(1, 12.2m, "4514561", "8546129856");
        }

        // Test avec des faux paramêtres
        [TestMethod]
        public void TestMethod3()
        {
            var bankTransfert = new BankTransfertSolid();
            bankTransfert.Transfert(1, -1000, "4514561", "8546129856");
        }

        // Test avec des paramêtres incohérents
        [TestMethod]
        public void TestMethod4()
        {
            var bankTransfert = new BankTransfertSolid();
            bankTransfert.Transfert(1111, -152021, "rpzeoizprt", "'à(_\"'(lfpaz");
        }
        #endregion
    }
}
