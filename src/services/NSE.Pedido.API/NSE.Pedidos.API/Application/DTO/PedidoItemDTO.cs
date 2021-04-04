using NSE.Pedidos.Domain.Pedidos;
using System;

namespace NSE.Pedidos.API.Application.DTO
{
    public class PedidoItemDTO
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int Quantidade { get; set; }

        public static PedidoItem ParaPedidoItem(PedidoItemDTO pedidoItemDTO)
        {
            return new PedidoItem(pedidoItemDTO.ProdutId, pedidoItemDTO.Nome, pedidoItemDTO.Quantidade, pedidoItemDTO.Valor);
        }
    }
}