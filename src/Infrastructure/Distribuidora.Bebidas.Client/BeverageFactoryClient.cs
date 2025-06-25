using System.Net;
using Distribuidora.Bebidas.Abstract.Client;
using Distribuidora.Bebidas.Domain.Client.BeverageFactory;

namespace Distribuidora.Bebidas.Client
{
    public class BeverageFactoryClient : IBeverageFactoryClient
    {
        private readonly Dictionary<int, HttpResponseMessage> _mock = new System.Collections.Generic.Dictionary<int, HttpResponseMessage>
        {
            [0] = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Mock integration") },
            [1] = new HttpResponseMessage(HttpStatusCode.BadGateway) { Content = new StringContent("Mock integration") },
            [2] = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Mock integration") },
            [3] = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Mock integration") },
        };
        public Task<HttpResponseMessage> RequestOrder(BeverageRequest order) 
        {
            Random random = new Random();
            var randomNumber = random.Next(0,3);
            return Task.FromResult(_mock[randomNumber] );

        }

    }
}
