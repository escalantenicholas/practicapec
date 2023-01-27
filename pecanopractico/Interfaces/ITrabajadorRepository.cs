using CsvHelper;
using pecanopractico.Models;
using pecanopractico.Views;

namespace pecanopractico.Interfaces
{
    public interface ITrabajadorRepository
    {
        List<TrabajadorView> GetAll();
        TrabajadorView GetByDni(string dni);
    }
}
