using MaisSabor2.Models;

namespace MaisSabor2.ViewModel
{
    public class ItemListViewModel
    {
        public IEnumerable<Item> Itens {get; set;}
        public string CategoriaAtual{get; set;}
    }
}