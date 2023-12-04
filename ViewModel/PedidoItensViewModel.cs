using MaisSabor2.Models;

namespace MaisSabor2.ViewModel
{
    public class PedidoItensViewModel
    {
        public Pedido Pedidos { get; set; }
        public IEnumerable<PedidoItem> PedidoItens { get; set; }
    }
}