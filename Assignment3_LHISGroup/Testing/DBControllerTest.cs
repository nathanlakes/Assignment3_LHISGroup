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
        
        public Boolean RunAllTests()
        {
            AddClientTest1();
            FindClientTest1();
            AddStaffTest1();
            AddSupplierTest1();
            AddWeddingTest1();
            AddWeddingTest2();
            AddWeddingTest3();
            AddTaskTest1();
            GetAllClientsTest();
            GetAllTasksTest1();
            GetAllStaffTest();
            GetAllSuppliersTest();
            GetAllWeddingsTest();
            UpdateTaskTest1();
            UpdatePersonOnTaskTest1();
            UpdateClientTest();
            UpdateSupplierTest();
            ChangeStaffActiveStatusTest();
            AllActiveStaffTest();
            DeleteSupplierTest();
            DeleteWeddingTest();
            DeleteTaskTest();
            return true;
        }
        /**
         * Only run this test.
         * For accurate results due to DB changes.
         * Only returns success if working on an empty DB.
        **/
        [Test]
        public void TestAll()
        {
            bool result = RunAllTests();
            Assert.AreEqual(true, result);
        }


        [Test]
        public void AddClientTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AddClientTest1");
            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Boolean i = testController.AddClient(testClient1);
            Assert.AreEqual(testClient1.Firstname, testController.FindClient(testClient1).Firstname);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void FindClientTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("FindClientTest1");
            int result = testController.FindClients("Jane").Count();
            Assert.AreEqual(1, result);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }
        


        [Test]
        public void AddStaffTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AddStaffTest1");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);
            testController.AddStaff(testStaff);
            Assert.AreEqual(testStaff.FirstName, testController.FindStaff(testStaff).FirstName);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void AddSupplierTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AddSupplierTest1");
            Supplier testSupplier = new Supplier("Jim Bastiras", "22 adress treet", "sasfasfa", "asdasd", "12214", 200);
            testController.AddSupplier(testSupplier);
            int i = testController.FindSupplier("Jim Bastiras").Count();
            Assert.AreEqual(1,i);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            
        }

        [Test]
        public void AddWeddingTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AddWeddingTest1");
            Client testClient1 = new Client("Jane", "Smith","Jane Smith","26 Oak Avenue", "23441212", "12098776","jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim","Deer","Jim Deer","861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254","cant work sundays", Staff.Active.active);

            testController.AddClient(testClient2);

            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime(), Wedding.Status.InPreparation);
            testController.AddWedding(testWedding);
            List<Wedding> testList = testController.FindWedding(testWedding.Title);
            Assert.AreEqual(testWedding.Title, testList.First().Title);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void AddWeddingTest2()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AddWeddingTest2");
            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim", "Deer", "Jim Deer", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);

            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime(), Wedding.Status.InPreparation);
            testController.AddWedding(testWedding);
            Wedding returnWedding = testController.FindWedding(2);

            Assert.AreEqual(testWedding.Title, returnWedding.Title);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void AddWeddingTest3()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AddWeddingTest3");
            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim", "Deer", "Jim Deer", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);

            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime(), Wedding.Status.InPreparation);
            testController.AddWedding(testWedding);
            Wedding returnWedding = testController.FindWedding(testWedding);

            Assert.AreEqual(testWedding.Title, returnWedding.Title);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void AddTaskTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AddTaskTest1");
            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim", "Deer", "Jim Deer", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);
            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime(), Wedding.Status.InPreparation);
            Task testTask = new Task("Shit", "description", Task.Priority.high, new DateTime(), testStaff, testWedding);
            Boolean i = testController.AddTask(testTask);
            Assert.AreEqual(true, i);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }
        
        [Test]
        public void GetAllClientsTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("GetAllClientsTest");
            List<Client> testList = testController.GetAllClients();
            int i = testList.Count();
            Assert.AreEqual(2, i);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void GetAllTasksTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("GetAllTasksTest1");
            List<Task> testList = testController.GetAllTasks();
            int i = testList.Count();
            Assert.AreEqual(1, i);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void GetAllStaffTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("GetAllStaffTest");
            List<Staff> testList = testController.GetAllStaff();
            int i = testList.Count();
            Assert.AreEqual(1, i);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }
     


        [Test]
        public void GetAllSuppliersTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("GetAllSuppliersTest");
            List<Supplier> testList = testController.GetAllSuppliers();
            int i = testList.Count();
            Assert.AreEqual(3, i);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void GetAllWeddingsTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("GetAllWeddingsTest");
            List<Wedding> testList = testController.GetAllWeddings();
            int i = testList.Count();
            Assert.AreEqual(3, i);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        

        [Test]
        public void UpdateTaskTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("UpdateTaskTest1");
            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim", "Deer", "Jim Deer", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);

            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime(), Wedding.Status.InPreparation);

            Task testTask = new Task("Shit", "description", Task.Priority.high, new DateTime(), testStaff, testWedding);

            Task testTask2 = new Task("Better Name", "description", Task.Priority.high, new DateTime(), testStaff, testWedding);
            Boolean i = testController.UpdateTask(1, testTask2);
            Assert.AreEqual(true, i);

            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void UpdatePersonOnTaskTest1()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("UpdatePersonOnTaskTest1");

            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim", "Deer", "Jim Deer", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);
            Staff testStaff2 = new Staff("Not Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);

            testController.AddStaff(testStaff2);
            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime(), Wedding.Status.InPreparation);

            Task testTask = new Task("Shit", "description", Task.Priority.high, new DateTime(), testStaff, testWedding);

            Boolean result = testController.UpdatePersonOnTask(testTask, testStaff2);
            Assert.AreEqual(true, result);

            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }



        [Test]
        public void UpdateClientTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("UpdateClientTest");
            Client testClient1 = new Client("NOTJANE", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Boolean result = testController.UpdateClient(1, testClient1);
            Assert.AreEqual(true, result);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

        }

        [Test]
        public void UpdateSupplierTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("UpdateSupplierTest");
            Supplier testSupplier = new Supplier("Jim NOT Bastiras", "22 adress treet", "sasfasfa", "asdasd", "12214", 200);
            Boolean result = testController.UpdateSupplier(1, testSupplier);
            Assert.AreEqual(true, result);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

        }


        [Test]
        public void ChangeStaffActiveStatusTest()
        {
           Console.WriteLine("----------------------------------------------------------------------------------------------------------");
           Console.WriteLine("ChangeStaffActiveStatusTest");
           Boolean result = testController.ChangeStaffActiveStatus(1, Staff.Active.inactive);
           Assert.AreEqual(true, result);
           Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }
        [Test]
        public void AllActiveStaffTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AllActiveStaffTest");
            List<Staff> testList = testController.AllActiveStaff();
            int result = testList.Count;
            Assert.AreEqual(2, result);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }
        [Test]
        public void DeleteSupplierTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("DeleteSupplierTest");
            Supplier testSupplier = new Supplier("Jim Bastiras", "22 adress treet", "sasfasfa", "asdasd", "12214", 200);

            Boolean result = testController.DeleteSupplier(1);
            Assert.AreEqual(true, result);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        
        [Test]
        public void DeleteWeddingTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("DeleteWeddingTest");
            Boolean result = testController.DeleteWedding(1);
            Assert.AreEqual(true, result);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        [Test]
        public void DeleteTaskTest()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("DeleteTaskTest");
            Boolean result = testController.DeleteTask(1);
            Assert.AreEqual(true, result);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }

    }
}
