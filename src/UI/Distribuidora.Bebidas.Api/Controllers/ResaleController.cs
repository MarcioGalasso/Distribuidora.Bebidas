using Microsoft.AspNetCore.Mvc;
using Distribuidora.Bebidas.Abstract.Services;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;
using Distribuidora.Bebidas.Domain.Broker.Producer;
using Distribuidora.Bebidas.Domain.Broker.Producer.Message;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Api.Controllers
{
    /// <summary>
    /// Controller para facilitar nos teste da aplicação!
    /// </summary>
    [Route("api/[controller]")]
    public class ResaleController : Controller
    {
        private readonly IResaleService _resaleService;

        public ResaleController(IResaleService resaleService)
        {
            _resaleService = resaleService;
        }
        /// <summary>
        /// Cadastro de revenda
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult> PostAsync([FromBody] ResaleRequest resale)
        {
            
            if(await _resaleService.AddAsync(resale))
            return Ok(resale);
            
            return BadRequest();
        }

        /// <summary>
        /// Busca de revenda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync([FromRoute] Guid id)
        {
            var resale = await _resaleService.GetAsync(id);
            if (resale!= default)
                return Ok(resale);

            return NoContent();
        }
    }
}
