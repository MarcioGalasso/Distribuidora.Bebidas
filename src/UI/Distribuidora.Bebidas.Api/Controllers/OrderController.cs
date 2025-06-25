using Microsoft.AspNetCore.Mvc;
using Distribuidora.Bebidas.Abstract.Services;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;
using Distribuidora.Bebidas.Domain.Broker.Producer;
using Distribuidora.Bebidas.Domain.Broker.Producer.Message;
using Distribuidora.Bebidas.Domain.Entities;
using Distribuidora.Bebidas.Domain.ViewModel.Order;

namespace Distribuidora.Bebidas.Api.Controllers
{
    /// <summary>
    /// Controller para facilitar nos teste da aplicação!
    /// </summary>
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        /// <summary>
        /// Cadastro de revenda
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult> PostAsync([FromBody] OrderRequest orderRequest)
        {
            
            if(await _orderService.AddAsync(orderRequest))
            return Ok(orderRequest);
            
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
            var resale = await _orderService.GetAsync(id);
            if (resale!= default)
                return Ok(resale);

            return NoContent();
        }
    }
}
