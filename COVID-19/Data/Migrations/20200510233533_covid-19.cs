using Microsoft.EntityFrameworkCore.Migrations;

namespace COVID_19.Data.Migrations
{
    public partial class covid19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dados_Paises_PaisesId",
                table: "Dados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dados",
                table: "Dados");

            migrationBuilder.DropIndex(
                name: "IX_Dados_PaisesId",
                table: "Dados");

            migrationBuilder.RenameTable(
                name: "Dados",
                newName: "DadosCovid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Paises",
                newName: "idPais");

            migrationBuilder.RenameColumn(
                name: "PaisesId",
                table: "DadosCovid",
                newName: "recuperados");

            migrationBuilder.AddColumn<string>(
                name: "nomePais",
                table: "Paises",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "confirmados",
                table: "DadosCovid",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mortes",
                table: "DadosCovid",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paisId",
                table: "DadosCovid",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DadosCovid",
                table: "DadosCovid",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_DadosCovid_paisId",
                table: "DadosCovid",
                column: "paisId");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosCovid_Paises_paisId",
                table: "DadosCovid",
                column: "paisId",
                principalTable: "Paises",
                principalColumn: "idPais",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DadosCovid_Paises_paisId",
                table: "DadosCovid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DadosCovid",
                table: "DadosCovid");

            migrationBuilder.DropIndex(
                name: "IX_DadosCovid_paisId",
                table: "DadosCovid");

            migrationBuilder.DropColumn(
                name: "nomePais",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "confirmados",
                table: "DadosCovid");

            migrationBuilder.DropColumn(
                name: "mortes",
                table: "DadosCovid");

            migrationBuilder.DropColumn(
                name: "paisId",
                table: "DadosCovid");

            migrationBuilder.RenameTable(
                name: "DadosCovid",
                newName: "Dados");

            migrationBuilder.RenameColumn(
                name: "idPais",
                table: "Paises",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "recuperados",
                table: "Dados",
                newName: "PaisesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dados",
                table: "Dados",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Dados_PaisesId",
                table: "Dados",
                column: "PaisesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dados_Paises_PaisesId",
                table: "Dados",
                column: "PaisesId",
                principalTable: "Paises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
