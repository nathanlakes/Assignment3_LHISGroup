﻿using System;
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
            Assert.AreEqual(testClient.Firstname, testController.FindClient(testClient).Firstname);
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
            int i = testController.FindSupplier("Jim Bastiras").Count();
            Assert.AreEqual(1,i);
            
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
            List<Wedding> testList = testController.FindWedding(testWedding.Title);
            Assert.AreEqual(testWedding.Title, testList.First());
        }

        [Test]
        public void AddWeddingTest2()
        {
            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim", "Deer", "Jim Deer", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);
            testController.AddClient(testClient1);
            testController.AddClient(testClient2);
            testController.AddStaff(testStaff);
            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime());
            testController.AddWedding(testWedding);
            Wedding returnWedding = testController.FindWedding(1);
            Assert.AreEqual(testWedding.Title, returnWedding.Title);
        }

        [Test]
        public void AddTaskTest1()
        {
            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim", "Deer", "Jim Deer", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);
            testController.AddClient(testClient1);
            testController.AddClient(testClient2);
            testController.AddStaff(testStaff);
            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime());
            testController.AddWedding(testWedding);
            Task testTask = new Task("Shit", "description", Task.Priority.high, new DateTime(), testStaff, testWedding);
            Boolean i = testController.AddTask(testTask);
            Assert.AreEqual(true, i);
        }
        
        [Test]
        public void GetAllClientsTest()
        {
            List<Client> testList = testController.GetAllClients();
            int i = testList.Count();
            Assert.AreEqual(2, i);
        }

        [Test]
        public void GetAllSuppliersTest()
        {
            List<Supplier> testList = testController.GetAllSuppliers();
            int i = testList.Count();
            Assert.AreEqual(2, i);
        }

        [Test]
        public void GetAllWeddingsTest()
        {
            List<Wedding> testList = testController.GetAllWeddings();
            int i = testList.Count();
            Assert.AreEqual(1, i);
        }

        [Test]
        public void GetAllTasksTest()
        {
            Client testClient1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Client testClient2 = new Client("Jim", "Deer", "Jim Deer", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Bobbie", "Wright");
            Staff testStaff = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);
            testController.AddClient(testClient1);
            testController.AddClient(testClient2);
            testController.AddStaff(testStaff);
            Wedding testWedding = new Wedding("THIS WEDDING", "descreption", testClient1, testClient2, testStaff, new DateTime(), new DateTime());
            testController.AddWedding(testWedding);
            Task testTask = new Task("Shit", "description", Task.Priority.high, new DateTime(), testStaff, testWedding);
            Boolean i = testController.AddTask(testTask);
            List<Task> testList = testController.GetAllTasks();
            int i2 = testList.Count();
            Assert.AreEqual(1, i2);
        }

        [Test]
        public void DeleteClientTest()
        {
            Boolean result = testController.DeleteClient(1);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateClientTest()
        {
            Client testClient1 = new Client("NOTJANE", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "John");
            Boolean result = testController.UpdateClient(1, testClient1);
            Assert.AreEqual(true, result);

        }

        [Test]
        public void UpdateSupplierTest()
        {
            Supplier testSupplier = new Supplier("Jim NOT Bastiras", "22 adress treet", "sasfasfa", "asdasd", "12214", 200);
            Boolean result = testController.UpdateSupplier(1, testSupplier);
            Assert.AreEqual(true, result);

        }

        [Test]
        public void DeleteSupplierTest()
        {
            Supplier testSupplier = new Supplier("Jim Bastiras", "22 adress treet", "sasfasfa", "asdasd", "12214", 200);
            testController.AddSupplier(testSupplier);
            Boolean result = testController.DeleteSupplier(1);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void DeleteTaskTest()
        {
            Boolean result = testController.DeleteTask(1);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void DeleteWeddingTest()
        {
            Boolean result = testController.DeleteWedding(1);
            Assert.AreEqual(true, result);
        }
    }
}
