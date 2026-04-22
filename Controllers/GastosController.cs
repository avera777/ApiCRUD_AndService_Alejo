using Microsoft.AspNetCore.Mvc;
using ApiGastos.Models;

namespace ApiGastos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private static readonly List<Gasto> gastos = new()
        {
            new Gasto
            {
                Id = 1,
                Descripcion = "Transporte",
                Monto = 25000,
                Fecha = DateTime.Now
            },
            new Gasto
            {
                Id = 2,
                Descripcion = "Almuerzo",
                Monto = 18000,
                Fecha = DateTime.Now
            }
        };

        [HttpGet]
        public ActionResult<List<Gasto>> Get()
        {
            return Ok(gastos);
        }
    }
}