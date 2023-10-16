using MaisSabor2.Models;
namespace MaisSabor2.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        public IEnumerable<Categoria> Categorias { get; }
    }
}