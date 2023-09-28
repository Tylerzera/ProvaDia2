using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartasController : ControllerBase
    {
        private readonly ICartaService _cartaService;

        public CartasController(ICartaService cartaService)
        {
            _cartaService = cartaService;
        }

        [HttpGet]
        public ActionResult<List<CartaViewModel>> Get()
        {
            var cartas = _cartaService.ListarCartas();
            return Ok(cartas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CartaViewModel newCarta)
        {
            var cartaCriada = _cartaService.CriarCarta(newCarta);
            return CreatedAtAction(nameof(Get), new { id = cartaCriada.Id }, cartaCriada);
        }
    }
}
