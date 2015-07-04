using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Assignment3_LHISGroup.Support_Classes
{
    [TestFixture]
    class DBControllerTest
    {
        DbController testController = new DbController();
        [Test]
        public void AddClientTest1()
        {
            Client testClient = new Client("Jim", "Bastiras", "contactTest", "222222", "3333333",
           "444444", "email", "Daniel", "Stone");
            Boolean i = testController.AddClient(testClient);
            Assert.AreEqual(testClient, testController.FindClient(testClient));
        }

        [Test]
        public void AddStaffTest1()
        {
            Staff testStaff = new Staff("Jimmy", "Bastiras", "email", "05231", "note", Staff.Active.active);
            testController.AddStaff(testStaff);
            Assert.AreEqual(testStaff, testController.FindStaff(testStaff));
        }
    }
}
