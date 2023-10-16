using MaisSabor2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaisSabor2.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaMenu(ICategoriaRepository categoriaRespository)
        {
            _categoriaRepository = categoriaRespository;
        }
        public IViewComponentResult Invoke()
        {
            var categoria = _categoriaRepository.Categorias.OrderBy(c =>

            c.Nome);

            return View(categoria);
        }
    }
}