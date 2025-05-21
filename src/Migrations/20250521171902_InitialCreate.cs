using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cycling_project_web_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mountains",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mountains", x => x.id);
                    table.UniqueConstraint("ak_mountains_name", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "nations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    still_exists = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nations", x => x.id);
                    table.UniqueConstraint("ak_nations_name", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "race_team_participations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_edition_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_race_team_participations", x => x.id);
                    table.UniqueConstraint("ak_race_team_participations_race_edition_id_team_id", x => new { x.race_edition_id, x.team_id });
                });

            migrationBuilder.CreateTable(
                name: "races",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    nation_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_races", x => x.id);
                    table.UniqueConstraint("ak_races_name", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "stage_combative_awards",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_combative_awards", x => x.id);
                    table.UniqueConstraint("ak_stage_combative_awards_stage_id", x => x.stage_id);
                });

            migrationBuilder.CreateTable(
                name: "stage_did_not_starts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_did_not_starts", x => x.id);
                    table.UniqueConstraint("ak_stage_did_not_starts_stage_id_race_rider_participation_id", x => new { x.stage_id, x.race_rider_participation_id });
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
                    table.UniqueConstraint("ak_stage_result_status_codes_name", x => x.name);
                    table.UniqueConstraint("ak_stage_result_status_codes_name_abbreviation", x => x.name_abbreviation);
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
                    table.UniqueConstraint("ak_stage_types_name", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "team_organizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "riders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    last_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
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
                name: "race_rider_participations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_team_participation_id = table.Column<int>(type: "integer", nullable: false),
                    rider_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_race_rider_participations", x => x.id);
                    table.UniqueConstraint("ak_race_rider_participations_race_team_participation_id_rider_", x => new { x.race_team_participation_id, x.rider_id });
                    table.ForeignKey(
                        name: "fk_race_rider_participations_race_team_participations_race_tea",
                        column: x => x.race_team_participation_id,
                        principalTable: "race_team_participations",
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
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    year = table.Column<short>(type: "smallint", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_race_editions", x => x.id);
                    table.UniqueConstraint("ak_race_editions_race_id_year", x => new { x.race_id, x.year });
                    table.ForeignKey(
                        name: "fk_race_editions_races_race_id",
                        column: x => x.race_id,
                        principalTable: "races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    year = table.Column<short>(type: "smallint", nullable: false),
                    team_organization_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                    table.UniqueConstraint("ak_teams_team_organization_id_year", x => new { x.team_organization_id, x.year });
                    table.ForeignKey(
                        name: "fk_teams_team_organizations_team_organization_id",
                        column: x => x.team_organization_id,
                        principalTable: "team_organizations",
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
                    stage_number = table.Column<short>(type: "smallint", nullable: false),
                    start_location = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    finish_location = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    distance_meters = table.Column<int>(type: "integer", nullable: false),
                    stage_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stages", x => x.id);
                    table.UniqueConstraint("ak_stages_race_edition_id_stage_number", x => new { x.race_edition_id, x.stage_number });
                    table.ForeignKey(
                        name: "fk_stages_race_editions_race_edition_id",
                        column: x => x.race_edition_id,
                        principalTable: "race_editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "riders_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<int>(type: "integer", nullable: false),
                    join_date = table.Column<DateOnly>(type: "date", nullable: false),
                    leave_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_riders_teams", x => x.id);
                    table.ForeignKey(
                        name: "fk_riders_teams_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_riders_teams_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mountain_climbs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mountain_id = table.Column<int>(type: "integer", nullable: false),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    climb_length_meter = table.Column<int>(type: "integer", nullable: false),
                    average_slope = table.Column<float>(type: "real", nullable: false),
                    distance_from_start_meters = table.Column<int>(type: "integer", nullable: false),
                    is_finish = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mountain_climbs", x => x.id);
                    table.ForeignKey(
                        name: "fk_mountain_climbs_mountains_mountain_id",
                        column: x => x.mountain_id,
                        principalTable: "mountains",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_mountain_climbs_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sprints",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    distance_from_start_meters = table.Column<int>(type: "integer", nullable: false),
                    is_finish = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sprints", x => x.id);
                    table.ForeignKey(
                        name: "fk_sprints_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
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
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false),
                    placement = table.Column<short>(type: "smallint", nullable: false),
                    finish_time_milliseconds = table.Column<int>(type: "integer", nullable: false),
                    stage_finish_status_code_id = table.Column<int>(type: "integer", nullable: false),
                    stage_result_status_code_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_rider_results", x => x.id);
                    table.UniqueConstraint("ak_stage_rider_results_stage_id_race_rider_participation_id", x => new { x.stage_id, x.race_rider_participation_id });
                    table.ForeignKey(
                        name: "fk_stage_rider_results_stage_result_status_codes_stage_result_",
                        column: x => x.stage_result_status_code_id,
                        principalTable: "stage_result_status_codes",
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
                name: "stage_rider_standings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false),
                    time_milliseconds = table.Column<int>(type: "integer", nullable: false),
                    time_penalty_seconds = table.Column<short>(type: "smallint", nullable: false),
                    bonus_seconds = table.Column<short>(type: "smallint", nullable: false),
                    sprint_points = table.Column<short>(type: "smallint", nullable: false),
                    sprint_points_penalty = table.Column<short>(type: "smallint", nullable: false),
                    mountain_points = table.Column<short>(type: "smallint", nullable: false),
                    mountain_points_penalty = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_rider_standings", x => x.id);
                    table.UniqueConstraint("ak_stage_rider_standings_stage_id_race_rider_participation_id", x => new { x.stage_id, x.race_rider_participation_id });
                    table.ForeignKey(
                        name: "fk_stage_rider_standings_stages_stage_id",
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
                    race_team_participation_id = table.Column<int>(type: "integer", nullable: false),
                    placement = table.Column<short>(type: "smallint", nullable: false),
                    finish_time_milliseconds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_team_results", x => x.id);
                    table.UniqueConstraint("ak_stage_team_results_stage_id_race_team_participation_id", x => new { x.stage_id, x.race_team_participation_id });
                    table.ForeignKey(
                        name: "fk_stage_team_results_race_team_participations_race_team_parti",
                        column: x => x.race_team_participation_id,
                        principalTable: "race_team_participations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stage_team_results_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stage_team_standings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_id = table.Column<int>(type: "integer", nullable: false),
                    race_team_participation_id = table.Column<int>(type: "integer", nullable: false),
                    time_milliseconds = table.Column<int>(type: "integer", nullable: false),
                    time_penalty_seconds = table.Column<short>(type: "smallint", nullable: false),
                    bonus_seconds = table.Column<short>(type: "smallint", nullable: false),
                    sprint_points = table.Column<short>(type: "smallint", nullable: false),
                    sprint_points_penalty = table.Column<short>(type: "smallint", nullable: false),
                    mountain_points = table.Column<short>(type: "smallint", nullable: false),
                    mountain_points_penalty = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_team_standings", x => x.id);
                    table.UniqueConstraint("ak_stage_team_standings_stage_id_race_team_participation_id", x => new { x.stage_id, x.race_team_participation_id });
                    table.ForeignKey(
                        name: "fk_stage_team_standings_stages_stage_id",
                        column: x => x.stage_id,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mountain_climb_reults",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mountain_climb_id = table.Column<int>(type: "integer", nullable: false),
                    placement = table.Column<short>(type: "smallint", nullable: false),
                    mountain_points = table.Column<short>(type: "smallint", nullable: false),
                    bonus_seconds = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mountain_climb_reults", x => x.id);
                    table.ForeignKey(
                        name: "fk_mountain_climb_reults_mountain_climbs_mountain_climb_id",
                        column: x => x.mountain_climb_id,
                        principalTable: "mountain_climbs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sprint_results",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sprint_id = table.Column<int>(type: "integer", nullable: false),
                    race_rider_participation_id = table.Column<int>(type: "integer", nullable: false),
                    placement = table.Column<short>(type: "smallint", nullable: false),
                    points = table.Column<short>(type: "smallint", nullable: false),
                    bonus_seconds = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sprint_results", x => x.id);
                    table.UniqueConstraint("ak_sprint_results_sprint_id_race_rider_participation_id", x => new { x.sprint_id, x.race_rider_participation_id });
                    table.ForeignKey(
                        name: "fk_sprint_results_race_rider_participations_race_rider_partici",
                        column: x => x.race_rider_participation_id,
                        principalTable: "race_rider_participations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sprint_results_sprints_sprint_id",
                        column: x => x.sprint_id,
                        principalTable: "sprints",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ix_mountain_climb_reults_mountain_climb_id",
                table: "mountain_climb_reults",
                column: "mountain_climb_id");

            migrationBuilder.CreateIndex(
                name: "ix_mountain_climbs_mountain_id",
                table: "mountain_climbs",
                column: "mountain_id");

            migrationBuilder.CreateIndex(
                name: "ix_mountain_climbs_stage_id",
                table: "mountain_climbs",
                column: "stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_riders_nation_id",
                table: "riders",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "ix_riders_teams_rider_id",
                table: "riders_teams",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "ix_riders_teams_team_id",
                table: "riders_teams",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_sprint_results_race_rider_participation_id",
                table: "sprint_results",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_sprints_stage_id",
                table: "sprints",
                column: "stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_results_stage_result_status_code_id",
                table: "stage_rider_results",
                column: "stage_result_status_code_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_team_results_race_team_participation_id",
                table: "stage_team_results",
                column: "race_team_participation_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mountain_climb_reults");

            migrationBuilder.DropTable(
                name: "riders_teams");

            migrationBuilder.DropTable(
                name: "sprint_results");

            migrationBuilder.DropTable(
                name: "stage_combative_awards");

            migrationBuilder.DropTable(
                name: "stage_did_not_starts");

            migrationBuilder.DropTable(
                name: "stage_rider_results");

            migrationBuilder.DropTable(
                name: "stage_rider_standings");

            migrationBuilder.DropTable(
                name: "stage_team_results");

            migrationBuilder.DropTable(
                name: "stage_team_standings");

            migrationBuilder.DropTable(
                name: "stage_types");

            migrationBuilder.DropTable(
                name: "mountain_climbs");

            migrationBuilder.DropTable(
                name: "riders");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "race_rider_participations");

            migrationBuilder.DropTable(
                name: "sprints");

            migrationBuilder.DropTable(
                name: "stage_result_status_codes");

            migrationBuilder.DropTable(
                name: "mountains");

            migrationBuilder.DropTable(
                name: "nations");

            migrationBuilder.DropTable(
                name: "team_organizations");

            migrationBuilder.DropTable(
                name: "race_team_participations");

            migrationBuilder.DropTable(
                name: "stages");

            migrationBuilder.DropTable(
                name: "race_editions");

            migrationBuilder.DropTable(
                name: "races");
        }
    }
}
