using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Pedidos.Infra.Migrations
{
    public partial class ImagemdoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdutoImagem",
                table: "PedidoItems",
                newName: "Imagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "PedidoItems",
                newName: "ProdutoImagem");
        }
    }
}
