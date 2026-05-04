using ApiGastos.Models;

namespace ApiGastos.Services
{
    public interface IGastoService
    {
        List<Gasto> GetAll();
        Gasto? GetById(int id);
        List<Gasto> Buscar(string descripcion);
        Gasto Crear(Gasto nuevo);
        bool Actualizar(int id, Gasto actualizado);
        bool Eliminar(int id);
    }
}