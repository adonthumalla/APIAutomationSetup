using Azure;
using Newtonsoft.Json;
using Restresreq.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace APIAutomationSetup
{

    // Create a client for the API
    public class UserHelper
    {
        private RestClient client;
        private RestRequest request;
        private const string baseUrl = "https://reqres.in/";

        public RestClient SetUrl(string endpoint) { 
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            return client;
        }
        /// Add any query parameters or headers needed
        public RestRequest CreateGetRequest() { 
            request= new RestRequest();
            request.AddHeader("Accept", "application/json");
            return request;
        }
        /// Add any query parameters or headers needed
        public RestRequest CreatePostRequest(string payload)
        {
            request= new RestRequest("", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json",payload, ParameterType.RequestBody);
            return request;
        }

        /// Add any query parameters or headers needed existing user data from the API
        public RestResponse GetResponse(RestClient restClient,RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public T GetContent<T>(RestResponse restResponse) { 
            var content = restResponse.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        /// Add any query parameters or headers to update the user data from the API
        public RestRequest CreatePutRequest(string payload)
        {
            request = new RestRequest(" ", Method.Put);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;

        }

        /// Add any query parameters or headers to delete the user data from the API
        public RestRequest CreateDeleteRequest()
        {
            request = new RestRequest("", Method.Delete);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public int GetStatusCode(RestResponse restResponse) {
            HttpStatusCode statusCode = restResponse.StatusCode;
            int httpStatusCode = (int)statusCode;
            return httpStatusCode;

        }

        /// Add any query parameters or headers to register the user data from the API
        public RestRequest CreateRegisterORLoginRequest(string payload)
        {
            request = new RestRequest(" ", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }
    }

}
