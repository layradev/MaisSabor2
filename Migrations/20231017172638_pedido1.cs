using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaisSabor2.Migrations
{
    /// <inheritdoc />
    public partial class pedido1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Itens_ItemId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Pedidos_PedidoId1",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_PedidoId1",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PedidoId1",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Itens_ItemId",
                table: "PedidoItens",
                column: "ItemId",
                principalTable: "Itens",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Itens_ItemId",
                table: "PedidoItens");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId1",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PedidoId1",
                table: "Pedidos",
                column: "PedidoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Itens_ItemId",
                table: "PedidoItens",
                column: "ItemId",
                principalTable: "Itens",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Pedidos_PedidoId1",
                table: "Pedidos",
                column: "PedidoId1",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }
    }
}
