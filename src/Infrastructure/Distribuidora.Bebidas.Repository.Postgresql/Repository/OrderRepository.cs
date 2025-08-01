﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Distribuidora.Bebidas.Abstract.Repository;
using Distribuidora.Bebidas.Domain.Entities;
using Distribuidora.Bebidas.Repository.Postgresql.Context;
using Distribuidora.Bebidas.Repository.Postgresql.Repository.Base;

namespace Distribuidora.Bebidas.Repository.Postgresql.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DistribuidoraContext context) : base(context)
        {
        }
    }
}
