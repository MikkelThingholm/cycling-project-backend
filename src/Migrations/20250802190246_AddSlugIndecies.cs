using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cycling_project_web_api.Migrations
{
    /// <inheritdoc />
    public partial class AddSlugIndecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "teams",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "riders",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "races",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "mountains",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "ix_teams_slug",
                table: "teams",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_riders_slug",
                table: "riders",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_races_slug",
                table: "races",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_mountains_slug",
                table: "mountains",
                column: "slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_teams_slug",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "ix_riders_slug",
                table: "riders");

            migrationBuilder.DropIndex(
                name: "ix_races_slug",
                table: "races");

            migrationBuilder.DropIndex(
                name: "ix_mountains_slug",
                table: "mountains");

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "teams",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "riders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "races",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "mountains",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);
        }
    }
}
