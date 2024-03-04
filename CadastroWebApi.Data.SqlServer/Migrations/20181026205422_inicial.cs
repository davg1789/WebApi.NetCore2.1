using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroWebApi.Data.SqlServer.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    Rg = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<Guid>(nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(30)", nullable: false),
                    Municipio = table.Column<string>(type: "varchar(30)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    IdTelefone = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Numero = table.Column<long>(type: "bigint", nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.IdTelefone);
                    table.ForeignKey(
                        name: "FK_Telefone_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdPessoa",
                table: "Endereco",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_IdPessoa",
                table: "Telefone",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
