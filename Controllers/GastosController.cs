using Microsoft.AspNetCore.Mvc;
using ApiGastos.Models;
using ApiGastos.Services;

namespace ApiGastos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly GastoService _service;

        public GastosController(GastoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Gasto>> Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Gasto> GetById(int id)
        {
            var gasto = _service.GetById(id);

            if (gasto == null)
                return NotFound($"No existe el gasto con id {id}");

            return Ok(gasto);
        }

        [HttpGet("buscar")]
        public ActionResult<List<Gasto>> Buscar([FromQuery] string descripcion)
        {
            var resultado = _service.Buscar(descripcion);

            if (!resultado.Any())
                return NotFound("No hay resultados");

            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Gasto nuevo)
        {
            var gastoCreado = _service.Crear(nuevo);
            return Ok(new { mensaje = "Gasto creado", data = gastoCreado });
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gasto actualizado)
        {
            var actualizadoOk = _service.Actualizar(id, actualizado);

            if (!actualizadoOk)
                return NotFound($"No existe el gasto con id {id}");

            return Ok(new { mensaje = "Gasto actualizado" });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eliminadoOk = _service.Eliminar(id);

            if (!eliminadoOk)
                return NotFound($"No existe el gasto con id {id}");

            return Ok(new { mensaje = "Gasto eliminado" });
        }
    }
}