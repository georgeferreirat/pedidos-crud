using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedidos.Migrations
{
    public partial class pedidosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    IdFornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailContato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeContato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.IdFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdeProdutod = table.Column<int>(type: "int", nullable: false),
                    FornecedorIdFornecedor = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Fornecedores_FornecedorIdFornecedor",
                        column: x => x.FornecedorIdFornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    PedidoIdPedido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Pedidos_PedidoIdPedido",
                        column: x => x.PedidoIdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FornecedorIdFornecedor",
                table: "Pedidos",
                column: "FornecedorIdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidoIdPedido",
                table: "Produtos",
                column: "PedidoIdPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
