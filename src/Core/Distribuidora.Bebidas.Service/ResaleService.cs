using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Distribuidora.Bebidas.Abstract.Repository;
using Distribuidora.Bebidas.Abstract.Services;
using Distribuidora.Bebidas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Distribuidora.Bebidas.Domain.Services
{
    public class ResaleService : IResaleService
    {
        private readonly IResaleRepository _resaleRepository;
        private readonly IMapper _mapper;

        public ResaleService(IResaleRepository resaleRepository, IMapper mapper)
        {
            _resaleRepository = resaleRepository;
            _mapper = mapper;
        }

        public Task<bool> AddAsync(ResaleRequest resaleRequest)
        {
            var resale = _mapper.Map<Resale>(resaleRequest);
            return _resaleRepository.AddAsync(resale);
        }
        public async Task<Resale> GetAsync(Guid id) => (await _resaleRepository.GetAllAsync(c => c.Include(t => t.Address).Include(t => t.Contact).Where(t => t.Id == id))).FirstOrDefault();
    }
}
