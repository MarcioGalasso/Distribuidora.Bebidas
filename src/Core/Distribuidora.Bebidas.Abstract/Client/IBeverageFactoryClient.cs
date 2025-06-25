using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.Bebidas.Domain.Client.BeverageFactory;

namespace Distribuidora.Bebidas.Abstract.Client
{
    public interface IBeverageFactoryClient
    {
        Task<HttpResponseMessage> RequestOrder(BeverageRequest order);
    }
}

