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
            Assert.AreEqual(testClient.Firstname, testController.FindClient(7).Firstname);
        }
        


        [Test]
        public void AddStaffTest1()
        {
            Staff testStaff = new Staff("Jimmy", "Bastiras", "email", "05231", "note", Staff.Active.active);
            testController.AddStaff(testStaff);
            Assert.AreEqual(testStaff, testController.FindStaff(testStaff));
        }

        [Test]
        public void AddSupplierTest1()
        {
            Supplier testSupplier = new Supplier("Jim Bastiras", "22 adress treet", "sasfasfa", "asdasd", "12214", 200);
            testController.AddSupplier(testSupplier);
            Assert.AreEqual(testSupplier, testController.FindSupplier(testSupplier.CompanyName));
            
        }
        [Test]
        public void AddWeddingTest1()
        {
            Client testClient1 = new Client("Jane", "Smith","Jane Smith","26 Oak Avenue", "23441212", "12098776","jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim","Deer","Jim Deer","861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254","cant work sundays", Staff.Active.active);
            testController.AddClient(testClient1);
            testController.AddClient(testClient2);
            testController.AddStaff(testStaff);
            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime());
            testController.AddWedding(testWedding);
            Assert.AreEqual(testWedding.Title, testController.FindWedding(1).Title);
        }
    }
}
