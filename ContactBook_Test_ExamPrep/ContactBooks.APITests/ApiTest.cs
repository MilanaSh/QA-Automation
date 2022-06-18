using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace ContactBooks.APITests
{
    public class ApiTest
    {
        private const string url = "http://localhost:8080/api/contacts";

        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient();
        }

        [Test]
        public void Test_GetAllClients_CheckFirstClient()
        {
            //Arrange
            this.request = new RestRequest(url);

            //Act
            var response = this.client.Execute(request);
            var contacts = JsonSerializer.Deserialize<List<Contacts>>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(contacts, Is.Not.Empty);
            Assert.That(contacts[0].firstName, Is.EqualTo("Steve"));
            Assert.That(contacts[0].lastName, Is.EqualTo("Jobs"));
        }

        [Test]
        public void Test_SearchClients_CheckFirstResult()
        {
            //Arrange
            this.request = new RestRequest(url + "/search/albert");

            //Act
            var response = this.client.Execute(request);
            var contacts = JsonSerializer.Deserialize<List<Contacts>>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(contacts, Is.Not.Empty);
            Assert.That(contacts[0].firstName, Is.EqualTo("Albert"));
            Assert.That(contacts[0].lastName, Is.EqualTo("Einstein"));
        }

        [Test]
        public void Test_SearchClients_EmptyResult()
        {
            //Arrange
            this.request = new RestRequest(url + "/search/{keyword}");
            request.AddUrlSegment("keyword", "missing3447");

            //Act
            var response = this.client.Execute(request);
            var contacts = JsonSerializer.Deserialize<List<Contacts>>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
           // Assert.That(contacts.Count, Is.EqualTo(0));
           Assert.That(contacts, Is.Empty);

        }

        [Test]
        public void Test_CreateContact_IvalidData()
        {
            //Arrange
            this.request = new RestRequest(url);
            var body = new
                { 
                    firstName = "Pesho",
                    email = "pesho@abv.bg",
                    phone = "0898771717"
                };
            request.AddJsonBody(body);

            //Act
            var response = this.client.Execute(request, Method.Post);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.EqualTo("{\"errMsg\":\"Last name cannot be empty!\"}"));

        }

        [Test]
        public void Test_CreateContact_ValidData()
        {
            //Arrange
            this.request = new RestRequest(url);
            var body = new
            {
                firstName = "Pesho" + DateTime.Now.Ticks,
                lastName = "Stoev" + DateTime.Now.Ticks,
                email = DateTime.Now.Ticks + "pesho@abv.bg",
                phone = "089" + DateTime.Now.Ticks
            };
            request.AddJsonBody(body);

            //Act
            var response = this.client.Execute(request, Method.Post);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
           
            var allContacts = this.client.Execute(request, Method.Get);
            var contacts = JsonSerializer.Deserialize<List<Contacts>>(allContacts.Content);

            var lastContact = contacts.Last();
            // var lastContact = contacts[contacts.Count - 1];

            Assert.That(lastContact.firstName, Is.EqualTo(body.firstName));
            Assert.That(lastContact.lastName, Is.EqualTo(body.lastName));

        }
    }
}