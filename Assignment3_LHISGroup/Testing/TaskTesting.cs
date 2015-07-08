using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    using NUnit.Framework;
    using Assignment3_LHISGroup.Support_Classes;
    [TestFixture]
    class TaskTesting
    {
        Task.Priority testPrio = Task.Priority.high;
        Staff testStaff = new Staff("Jim", "Bastiras", "email", "00000", "blah blah", Staff.Active.active);
        Client testClient1 = new Client("Jimmy", "Bastiras", "kalfslasf", "aflklsafl", "00000000000", "00340602", "gmail", "Daniel", "Stone");
        Client testClient2 = new Client("Daniel", "Stone", "kalfslasf", "aflklsafl", "00000000000", "00340602", "gmail", "Jimmy", "Bastiras");
        

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CompleteBySetTest1()
        {
            Wedding testWedding = new Wedding("Wedding1", "decription", testClient1, testClient2, testStaff, new DateTime(2014, 1, 18), new DateTime(2014, 1, 22), Wedding.Status.InPreparation);
            Task testTask = new Task("testing", "does things", testPrio, new DateTime(), testStaff, testWedding);
            testTask.CompleteBy = new DateTime(2014, 1, 18);
        }

        [Test]
        public void CompleteBySetTest2()
        {
            Wedding testWedding = new Wedding("Wedding1", "decription", testClient1, testClient2, testStaff, new DateTime(2014, 1, 18), new DateTime(2014, 1, 22), Wedding.Status.InPreparation);
            Task testTask = new Task("testing", "does things", testPrio, new DateTime(), testStaff, testWedding);
            testTask.CompleteBy = new DateTime(2015, 12, 18);
            Assert.AreEqual(new DateTime(2015, 12, 18), testTask.CompleteBy);
        }

        

        [Test]
        public void CompletionDateGetTest1()
        {
            Wedding testWedding = new Wedding("Wedding1", "decription", testClient1, testClient2, testStaff, new DateTime(2014, 1, 18), new DateTime(2014, 1, 22), Wedding.Status.InPreparation);
            Task testTask = new Task("testing", "does things", testPrio, new DateTime(), testStaff, testWedding);
            DateTime result = (DateTime)testTask.CompletionDate;
            Assert.AreEqual(result, DateTime.MinValue);
        }

        [Test]
        public void CompletionSetDateTest1()
        {
            Wedding testWedding = new Wedding("Wedding1", "decription", testClient1, testClient2, testStaff, new DateTime(2014, 1, 18), new DateTime(2014, 1, 22), Wedding.Status.InPreparation);
            Task testTask = new Task("testing", "does things", testPrio, new DateTime(), testStaff, testWedding);
            testTask.CompletionDate = new DateTime(2015, 07, 18);
            Assert.AreEqual(new DateTime(2015, 07, 18), testTask.CompletionDate);
        }

   
    }
}
