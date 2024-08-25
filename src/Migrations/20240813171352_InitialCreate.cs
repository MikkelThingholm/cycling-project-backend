using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace cycling_project_web_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meta_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meta_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    still_exists = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stage_finish_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_finish_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    year = table.Column<short>(type: "Int2", nullable: false),
                    meta_team_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                    table.ForeignKey(
                        name: "fk_teams_meta_teams_meta_team_id",
                        column: x => x.meta_team_id,
                        principalTable: "meta_teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "races",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nation_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_races", x => x.id);
                    table.ForeignKey(
                        name: "fk_races_nations_nation_id",
                        column: x => x.nation_id,
                        principalTable: "nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "riders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nation_id = table.Column<int>(type: "integer", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_riders", x => x.id);
                    table.ForeignKey(
                        name: "fk_riders_nations_nation_id",
                        column: x => x.nation_id,
                        principalTable: "nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "old_race_name",
                columns: table => new
                {
                    key = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_old_race_name", x => x.key);
                    table.ForeignKey(
                        name: "fk_old_race_name_races_race_id",
                        column: x => x.race_id,
                        principalTable: "races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "race_editions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_id = table.Column<int>(type: "integer", nullable: false),
                    class_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    year = table.Column<short>(type: "Int2", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    race_edition_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_race_editions", x => x.id);
                    table.ForeignKey(
                        name: "fk_race_editions_races_race_id",
                        column: x => x.race_id,
                        principalTable: "races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rider_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<int>(type: "integer", nullable: false),
                    start = table.Column<DateOnly>(type: "date", nullable: false),
                    end = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rider_teams", x => x.id);
                    table.ForeignKey(
                        name: "fk_rider_teams_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rider_teams_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_edition_id = table.Column<int>(type: "integer", nullable: false),
                    stage_number = table.Column<short>(type: "Int2", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    distance = table.Column<int>(type: "integer", nullable: false),
                    stage_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stages", x => x.id);
                    table.ForeignKey(
                        name: "fk_stages_race_editions_race_edition_id",
                        column: x => x.race_edition_id,
                        principalTable: "race_editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stage_rider_results",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    placement = table.Column<short>(type: "Int2", nullable: false),
                    finish_time = table.Column<int>(type: "integer", nullable: false),
                    sprint_point_obtained = table.Column<short>(type: "Int2", nullable: false),
                    climbing_point_obtained = table.Column<short>(type: "Int2", nullable: false),
                    bonus_point_obtained = table.Column<short>(type: "Int2", nullable: false),
                    time_penalty = table.Column<short>(type: "Int2", nullable: false),
                    stage_finish_status_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_rider_results", x => x.id);
                    table.ForeignKey(
                        name: "fk_stage_rider_results_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stage_rider_results_stage_finish_statuses_stage_finish_stat",
                        column: x => x.stage_finish_status_id,
                        principalTable: "stage_finish_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stage_rider_results_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stage_team_results",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<int>(type: "integer", nullable: false),
                    placement = table.Column<short>(type: "Int2", nullable: false),
                    finish_time = table.Column<int>(type: "integer", nullable: false),
                    time_penalty = table.Column<short>(type: "Int2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_team_results", x => x.id);
                    table.ForeignKey(
                        name: "fk_stage_team_results_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stage_team_results_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_old_race_name_race_id",
                table: "old_race_name",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "ix_race_editions_race_id",
                table: "race_editions",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "ix_races_nation_id",
                table: "races",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "ix_rider_teams_rider_id",
                table: "rider_teams",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "ix_rider_teams_team_id",
                table: "rider_teams",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_riders_nation_id",
                table: "riders",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_results_rider_id",
                table: "stage_rider_results",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_results_stage_finish_status_id",
                table: "stage_rider_results",
                column: "stage_finish_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_results_stage_id",
                table: "stage_rider_results",
                column: "stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_team_results_stage_id",
                table: "stage_team_results",
                column: "stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_team_results_team_id",
                table: "stage_team_results",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_stages_race_edition_id",
                table: "stages",
                column: "race_edition_id");

            migrationBuilder.CreateIndex(
                name: "ix_teams_meta_team_id",
                table: "teams",
                column: "meta_team_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "old_race_name");

            migrationBuilder.DropTable(
                name: "rider_teams");

            migrationBuilder.DropTable(
                name: "stage_rider_results");

            migrationBuilder.DropTable(
                name: "stage_team_results");

            migrationBuilder.DropTable(
                name: "riders");

            migrationBuilder.DropTable(
                name: "stage_finish_statuses");

            migrationBuilder.DropTable(
                name: "stages");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "race_editions");

            migrationBuilder.DropTable(
                name: "meta_teams");

            migrationBuilder.DropTable(
                name: "races");

            migrationBuilder.DropTable(
                name: "nations");
        }
    }
}
