using MaisSabor2.Context;
using MaisSabor2.Models;
using MaisSabor2.Repositories.Interfaces;

 namespace MaisSabor2.Repositories
 {
    public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;
    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Categoria> Categorias => _context.Categorias;
}
 }

