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

        // Create a request to put/update data from the API
        [TestMethod]
        public void testCreatePutRequest()
        {
            string payload = @"{ ""name"": ""morpheus"",""job"": ""zion resident""}";
            var api = new RequestResponseTest();
            var response = api.CreatePutRequest(payload);
            Assert.AreEqual("zion resident", response.job);
        }

        // Create a request to delete data from the API
        [TestMethod]
        public void testDeleteRequest()
        {
            var api = new RequestResponseTest();
            var statusCode = api.CreateDeleteRequest();
            Assert.AreEqual(204, statusCode);
        }

        // Create a request to register successful data from the API
        [TestMethod]
        public void testRegisterUserSuccessful()
        {
            string payload = @"{ ""email"": ""eve.holt@reqres.in"",""password"": ""pistol""}";
            var api = new RequestResponseTest();
            var response = api.CreateRegisterRequest(payload);
            Assert.AreEqual(4, response.id);
        }

        [TestMethod]
        public void testRegisterUserUnsucessful()
        {
            string payload = @"{ ""email"": ""eve.holt@reqres.in"",""password"": """"}";
            var api = new RequestResponseTest();
            var statusCode = api.CreateRegisterUnsuccessfulRequest(payload);
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void testLoginUser()
        {
            string payload = @"{ ""email"": ""eve.holt@reqres.in"",""password"": ""cityslicka""}";
            var api = new RequestResponseTest();
            var response = api.CreateUserLoginReq(payload);
            Assert.AreEqual("QpwL5tke4Pnpja7X4", response.token);
        }

        [TestMethod]
        public void testSingleResourceFound()
        {
            var api = new RequestResponseTest();
            var statusCode = api.getSingleResourceReq("api/unknown/2");
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void testSingleResourceNotFound()
        {
            var api = new RequestResponseTest();
            var statusCode = api.getSingleResourceReq("api/unknown/23");
            Assert.AreEqual(404, statusCode);
        }
    }
}
