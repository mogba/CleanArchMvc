using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Product (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno1.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Product (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Estojo escolar', 'Estojo escolar Homem-Aranha no Aranhaverso', 21.90, 30, 'estojo-homem-aranha-aranhaverso.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Product (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Borracha', 'Borracha redonda', 8.49, 25, 'borracha-redonda.jpg', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Product");
        }
    }
}
