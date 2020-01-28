using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFincasWeb.Repository.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(maxLength: 100, nullable: false),
                    valor = table.Column<decimal>(nullable: false),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_exclusao = table.Column<DateTime>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    valor = table.Column<decimal>(nullable: false),
                    data_inclusao = table.Column<DateTime>(nullable: false),
                    tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<byte[]>(maxLength: 64, nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: true),
                    sobrenome = table.Column<string>(maxLength: 100, nullable: true),
                    role = table.Column<string>(maxLength: 10, nullable: false),
                    salt = table.Column<byte[]>(maxLength: 128, nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
