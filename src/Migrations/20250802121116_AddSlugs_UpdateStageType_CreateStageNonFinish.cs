using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cycling_project_web_api.Migrations
{
    /// <inheritdoc />
    public partial class AddSlugs_UpdateStageType_CreateStageNonFinish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climb_results_race_mountain_climb_id",
                table: "mountain_climb_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_results_stage_result_status_codes_stage_result_",
                table: "stage_rider_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stages_stage_types_stage_type_id",
                table: "stages");

            migrationBuilder.DropTable(
                name: "stage_combative_awards");

            migrationBuilder.DropTable(
                name: "stage_did_not_starts");

            migrationBuilder.DropTable(
                name: "stage_result_status_codes");

            migrationBuilder.DropTable(
                name: "stage_types");

            migrationBuilder.DropIndex(
                name: "ix_stages_stage_type_id",
                table: "stages");

            migrationBuilder.DropIndex(
                name: "ix_stage_rider_results_stage_result_status_code_id",
                table: "stage_rider_results");

            migrationBuilder.DropColumn(
                name: "stage_result_status_code_id",
                table: "stage_rider_results");

            migrationBuilder.RenameColumn(
                name: "stage_type_id",
                table: "stages",
                newName: "stage_type");

            migrationBuilder.RenameColumn(
                name: "climb_length_meter",
                table: "mountain_climbs",
                newName: "climb_length_meters");

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "riders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "races",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "mountains",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "stage_combativity_awards",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_combativity_awards", x => x.id);
                    table.ForeignKey(
                        name: "fk_stage_combativity_awards_race_rider_participations_race_rid",
                        column: x => x.race_rider_participation_id,
                        principalTable: "race_rider_participations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stage_combativity_awards_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stage_non_finishes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_non_finishes", x => x.id);
                    table.ForeignKey(
                        name: "fk_stage_non_finishes_race_rider_participations_race_rider_par",
                        column: x => x.race_rider_participation_id,
                        principalTable: "race_rider_participations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stage_non_finishes_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_stage_combativity_awards_race_rider_participation_id",
                table: "stage_combativity_awards",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_combativity_awards_stage_id",
                table: "stage_combativity_awards",
                column: "stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_non_finishes_race_rider_participation_id",
                table: "stage_non_finishes",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_non_finishes_stage_id_race_rider_participation_id",
                table: "stage_non_finishes",
                columns: new[] { "stage_id", "race_rider_participation_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climb_results_mountain_climbs_mountain_climb_id",
                table: "mountain_climb_results",
                column: "mountain_climb_id",
                principalTable: "mountain_climbs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climb_results_mountain_climbs_mountain_climb_id",
                table: "mountain_climb_results");

            migrationBuilder.DropTable(
                name: "stage_combativity_awards");

            migrationBuilder.DropTable(
                name: "stage_non_finishes");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "riders");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "races");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "mountains");

            migrationBuilder.RenameColumn(
                name: "stage_type",
                table: "stages",
                newName: "stage_type_id");

            migrationBuilder.RenameColumn(
                name: "climb_length_meters",
                table: "mountain_climbs",
                newName: "climb_length_meter");

            migrationBuilder.AddColumn<int>(
                name: "stage_result_status_code_id",
                table: "stage_rider_results",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "stage_combative_awards",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false),
                    stage_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_combative_awards", x => x.id);
                    table.ForeignKey(
                        name: "fk_stage_combative_awards_race_rider_participations_race_rider",
                        column: x => x.race_rider_participation_id,
                        principalTable: "race_rider_participations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stage_combative_awards_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stage_did_not_starts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false),
                    stage_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_did_not_starts", x => x.id);
                    table.ForeignKey(
                        name: "fk_stage_did_not_starts_race_rider_participations_race_rider_p",
                        column: x => x.race_rider_participation_id,
                        principalTable: "race_rider_participations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stage_did_not_starts_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stage_result_status_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    name_abbreviation = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_result_status_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stage_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_types", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "stage_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Flat" },
                    { 2, "Hilly" },
                    { 3, "Mountain" },
                    { 4, "Individual time trial" },
                    { 5, "Team time trial" },
                    { 6, "Individual mountain time trial" },
                    { 7, "Cobblestone" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_stages_stage_type_id",
                table: "stages",
                column: "stage_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_results_stage_result_status_code_id",
                table: "stage_rider_results",
                column: "stage_result_status_code_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_combative_awards_race_rider_participation_id",
                table: "stage_combative_awards",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_combative_awards_stage_id_race_rider_participation_id",
                table: "stage_combative_awards",
                columns: new[] { "stage_id", "race_rider_participation_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_did_not_starts_race_rider_participation_id",
                table: "stage_did_not_starts",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_did_not_starts_stage_id_race_rider_participation_id",
                table: "stage_did_not_starts",
                columns: new[] { "stage_id", "race_rider_participation_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_result_status_codes_name",
                table: "stage_result_status_codes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_result_status_codes_name_abbreviation",
                table: "stage_result_status_codes",
                column: "name_abbreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_types_name",
                table: "stage_types",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climb_results_race_mountain_climb_id",
                table: "mountain_climb_results",
                column: "mountain_climb_id",
                principalTable: "mountain_climbs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_rider_results_stage_result_status_codes_stage_result_",
                table: "stage_rider_results",
                column: "stage_result_status_code_id",
                principalTable: "stage_result_status_codes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stages_stage_types_stage_type_id",
                table: "stages",
                column: "stage_type_id",
                principalTable: "stage_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
