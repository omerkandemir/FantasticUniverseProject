using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_CreatedBy_ModifiedBy_Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Universes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Universes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Unions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Unions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "UnionCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "UnionCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "TimeLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "TimeLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Stars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Stars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Galaxies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Galaxies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Adventures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Adventures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "AdventureCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "AdventureCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "AbilityCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "AbilityCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Unions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Unions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UnionCharacters");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "UnionCharacters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TimeLines");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TimeLines");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Galaxies");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Galaxies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Adventures");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Adventures");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AdventureCharacters");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AdventureCharacters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AbilityCharacters");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AbilityCharacters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Abilities");
        }
    }
}
