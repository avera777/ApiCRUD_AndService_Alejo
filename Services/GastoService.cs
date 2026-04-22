using ApiGastos.Models;

namespace ApiGastos.Services
{
    public class GastoService
    {
        private readonly List<Gasto> gastos = new()
        {
            new Gasto { Id = 1, Descripcion = "Transporte", Monto = 25000, Fecha = DateTime.Now },
            new Gasto { Id = 2, Descripcion = "Almuerzo", Monto = 18000, Fecha = DateTime.Now }
        };

        public List<Gasto> GetAll()
        {
            return gastos;
        }

        public Gasto? GetById(int id)
        {
            return gastos.FirstOrDefault(g => g.Id == id);
        }

        public List<Gasto> Buscar(string descripcion)
        {
            return gastos
                .Where(g => g.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Gasto Crear(Gasto nuevo)
        {
            nuevo.Id = gastos.Any() ? gastos.Max(g => g.Id) + 1 : 1;
            gastos.Add(nuevo);
            return nuevo;
        }

        public bool Actualizar(int id, Gasto actualizado)
        {
            var gasto = gastos.FirstOrDefault(g => g.Id == id);
            if (gasto == null) return false;

            gasto.Descripcion = actualizado.Descripcion;
            gasto.Monto = actualizado.Monto;
            gasto.Fecha = actualizado.Fecha;

            return true;
        }

        public bool Eliminar(int id)
        {
            var gasto = gastos.FirstOrDefault(g => g.Id == id);
            if (gasto == null) return false;

            gastos.Remove(gasto);
            return true;
        }
    }
}