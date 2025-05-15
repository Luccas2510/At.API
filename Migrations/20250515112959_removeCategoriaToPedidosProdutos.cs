using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace At.API.Migrations
{
    /// <inheritdoc />
    public partial class removeCategoriaToPedidosProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosProdutos_Categorias_CategoriaId",
                table: "PedidosProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosProdutos_Produtos_ProdutoId",
                table: "PedidosProdutos");

            migrationBuilder.DropIndex(
                name: "IX_PedidosProdutos_CategoriaId",
                table: "PedidosProdutos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "PedidosProdutos");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "PedidosProdutos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "PedidosProdutos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_PedidoId",
                table: "PedidosProdutos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosProdutos_Pedidos_PedidoId",
                table: "PedidosProdutos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosProdutos_Produtos_ProdutoId",
                table: "PedidosProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosProdutos_Pedidos_PedidoId",
                table: "PedidosProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosProdutos_Produtos_ProdutoId",
                table: "PedidosProdutos");

            migrationBuilder.DropIndex(
                name: "IX_PedidosProdutos_PedidoId",
                table: "PedidosProdutos");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "PedidosProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "PedidosProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "PedidosProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_CategoriaId",
                table: "PedidosProdutos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosProdutos_Categorias_CategoriaId",
                table: "PedidosProdutos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosProdutos_Produtos_ProdutoId",
                table: "PedidosProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
