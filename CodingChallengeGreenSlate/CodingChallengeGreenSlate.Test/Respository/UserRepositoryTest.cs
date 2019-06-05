using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Test.Respository
{
    [TestClass]
    public class UserRepositoryTest
    {
        DbConnection connection;
        TestContextEF databaseContext;
        UserRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new TestContextEF(connection);
            objRepo = new UserRepository(databaseContext);

        }

        [TestMethod]
        public void User_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("User 1", result[0].FirstName);
            Assert.AreEqual("User 2", result[1].FirstName);
            Assert.AreEqual("User 3", result[2].FirstName);
            Assert.AreEqual("LastName 1", result[0].LastName);
            Assert.AreEqual("LastName 2", result[1].LastName);
            Assert.AreEqual("LastName 3", result[2].LastName);
        }

        [TestMethod]
        public void User_Repository_Create()
        {
            //Arrange
            User c = new User() { FirstName = "User 4", LastName = "LastName 4" };

            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("User 4", lst.Last().FirstName);
        }
    }
}

