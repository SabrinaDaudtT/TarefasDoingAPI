using Microsoft.EntityFrameworkCore.Migrations;

namespace TarefasDoingAPI.Migrations
{
    public partial class TarefaSincronizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tarefas",
                newName: "IdTarefaAPI");

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Tarefas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IdtTarefaApp",
                table: "Tarefas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdtTarefaApp",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "IdTarefaAPI",
                table: "Tarefas",
                newName: "Id");
        }
    }
}
