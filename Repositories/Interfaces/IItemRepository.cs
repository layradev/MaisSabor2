using MaisSabor2.Models;

namespace MaisSabor2.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> Itens {get;}
        IEnumerable<Item> ItensEmDestaque {get;}
        Item GetItemById(int itemId);
    }
}