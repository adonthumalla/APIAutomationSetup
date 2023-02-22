using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIAutomationSetup;
using System;
using Restresreq.Models;

namespace APITests
{
    [TestClass]
    public class UsersCRUDTest
    {
        // Create a request to get data from the API
        [TestMethod]
        public void testGetUsers()
        {
            var api = new RequestResponseTest();
            var response = api.getUsers();
            Assert.AreEqual(2, response.page);
        }


        // Create a request to post data from the API

        [TestMethod]
        public void testCreateUser()
        {
            string payload = @"{ ""name"": ""morpheus"",""job"": ""leader""}";
            var api = new RequestResponseTest();
            var response = api.CreateNewUser(payload);
            Assert.AreEqual("morpheus", response.name);
        }
        // Create a request to get existing user data from the API
        [TestMethod]
        public void testSpecificUserExistence()
        {
            //This value should be read from the data testing through CSV
            UserData userData = new UserData {email = "lindsay.ferguson@reqres.in", first_name = "Lindsay", last_name = "Ferguson", id =8 , avatar= "https://reqres.in/img/faces/8-image.jpg" };
            var api = new RequestResponseTest();
            var response = api.getAllUsers();
            CollectionAssert.Contains(response.data, userData);
        }
    }
}
