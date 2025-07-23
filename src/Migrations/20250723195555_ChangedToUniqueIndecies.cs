using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cycling_project_web_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToUniqueIndecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climb_reults_mountain_climbs_mountain_climb_id",
                table: "mountain_climb_reults");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_teams_team_organization_id_year",
                table: "teams");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stages_race_edition_id_stage_number",
                table: "stages");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_types_name",
                table: "stage_types");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_team_standings_stage_id_race_team_participation_id",
                table: "stage_team_standings");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_team_results_stage_id_race_team_participation_id",
                table: "stage_team_results");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_rider_standings_stage_id_race_rider_participation_id",
                table: "stage_rider_standings");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_rider_results_stage_id_race_rider_participation_id",
                table: "stage_rider_results");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_result_status_codes_name",
                table: "stage_result_status_codes");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_result_status_codes_name_abbreviation",
                table: "stage_result_status_codes");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_did_not_starts_stage_id_race_rider_participation_id",
                table: "stage_did_not_starts");

            migrationBuilder.DropIndex(
                name: "ix_stage_combative_awards_stage_id",
                table: "stage_combative_awards");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_sprint_results_sprint_id_race_rider_participation_id",
                table: "sprint_results");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_races_name",
                table: "races");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_race_team_participations_race_edition_id_team_id",
                table: "race_team_participations");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_race_rider_participations_race_team_participation_id_rider_",
                table: "race_rider_participations");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_race_editions_race_id_year",
                table: "race_editions");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_nations_name",
                table: "nations");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_mountains_name",
                table: "mountains");

            migrationBuilder.DropPrimaryKey(
                name: "pk_mountain_climb_reults",
                table: "mountain_climb_reults");

            migrationBuilder.DropColumn(
                name: "mountain_points",
                table: "stage_team_standings");

            migrationBuilder.DropColumn(
                name: "mountain_points_penalty",
                table: "stage_team_standings");

            migrationBuilder.DropColumn(
                name: "sprint_points",
                table: "stage_team_standings");

            migrationBuilder.RenameTable(
                name: "mountain_climb_reults",
                newName: "mountain_climb_results");

            migrationBuilder.RenameColumn(
                name: "sprint_points_penalty",
                table: "stage_team_standings",
                newName: "placement");

            migrationBuilder.RenameIndex(
                name: "ix_mountain_climb_reults_mountain_climb_id",
                table: "mountain_climb_results",
                newName: "ix_mountain_climb_results_mountain_climb_id");

            migrationBuilder.AddColumn<short>(
                name: "placement",
                table: "stage_rider_standings",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_mountain_climb_results",
                table: "mountain_climb_results",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_teams_team_organization_id_year",
                table: "teams",
                columns: new[] { "team_organization_id", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stages_race_edition_id_stage_number",
                table: "stages",
                columns: new[] { "race_edition_id", "stage_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_types_name",
                table: "stage_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_team_standings_stage_id_race_team_participation_id",
                table: "stage_team_standings",
                columns: new[] { "stage_id", "race_team_participation_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_team_results_stage_id_race_team_participation_id",
                table: "stage_team_results",
                columns: new[] { "stage_id", "race_team_participation_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_standings_stage_id_race_rider_participation_id",
                table: "stage_rider_standings",
                columns: new[] { "stage_id", "race_rider_participation_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_results_stage_id_race_rider_participation_id",
                table: "stage_rider_results",
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
                name: "ix_stage_did_not_starts_stage_id_race_rider_participation_id",
                table: "stage_did_not_starts",
                columns: new[] { "stage_id", "race_rider_participation_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stage_combative_awards_stage_id_race_rider_participation_id",
                table: "stage_combative_awards",
                columns: new[] { "stage_id", "race_rider_participation_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sprint_results_sprint_id_race_rider_participation_id",
                table: "sprint_results",
                columns: new[] { "sprint_id", "race_rider_participation_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_races_name",
                table: "races",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_race_team_participations_race_edition_id_team_id",
                table: "race_team_participations",
                columns: new[] { "race_edition_id", "team_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_race_rider_participations_race_team_participation_id_rider_",
                table: "race_rider_participations",
                columns: new[] { "race_team_participation_id", "rider_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_race_editions_race_id_year",
                table: "race_editions",
                columns: new[] { "race_id", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_nations_name",
                table: "nations",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_mountains_name",
                table: "mountains",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climb_results_race_mountain_climb_id",
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
                name: "fk_mountain_climb_results_race_mountain_climb_id",
                table: "mountain_climb_results");

            migrationBuilder.DropIndex(
                name: "ix_teams_team_organization_id_year",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "ix_stages_race_edition_id_stage_number",
                table: "stages");

            migrationBuilder.DropIndex(
                name: "ix_stage_types_name",
                table: "stage_types");

            migrationBuilder.DropIndex(
                name: "ix_stage_team_standings_stage_id_race_team_participation_id",
                table: "stage_team_standings");

            migrationBuilder.DropIndex(
                name: "ix_stage_team_results_stage_id_race_team_participation_id",
                table: "stage_team_results");

            migrationBuilder.DropIndex(
                name: "ix_stage_rider_standings_stage_id_race_rider_participation_id",
                table: "stage_rider_standings");

            migrationBuilder.DropIndex(
                name: "ix_stage_rider_results_stage_id_race_rider_participation_id",
                table: "stage_rider_results");

            migrationBuilder.DropIndex(
                name: "ix_stage_result_status_codes_name",
                table: "stage_result_status_codes");

            migrationBuilder.DropIndex(
                name: "ix_stage_result_status_codes_name_abbreviation",
                table: "stage_result_status_codes");

            migrationBuilder.DropIndex(
                name: "ix_stage_did_not_starts_stage_id_race_rider_participation_id",
                table: "stage_did_not_starts");

            migrationBuilder.DropIndex(
                name: "ix_stage_combative_awards_stage_id_race_rider_participation_id",
                table: "stage_combative_awards");

            migrationBuilder.DropIndex(
                name: "ix_sprint_results_sprint_id_race_rider_participation_id",
                table: "sprint_results");

            migrationBuilder.DropIndex(
                name: "ix_races_name",
                table: "races");

            migrationBuilder.DropIndex(
                name: "ix_race_team_participations_race_edition_id_team_id",
                table: "race_team_participations");

            migrationBuilder.DropIndex(
                name: "ix_race_rider_participations_race_team_participation_id_rider_",
                table: "race_rider_participations");

            migrationBuilder.DropIndex(
                name: "ix_race_editions_race_id_year",
                table: "race_editions");

            migrationBuilder.DropIndex(
                name: "ix_nations_name",
                table: "nations");

            migrationBuilder.DropIndex(
                name: "ix_mountains_name",
                table: "mountains");

            migrationBuilder.DropPrimaryKey(
                name: "pk_mountain_climb_results",
                table: "mountain_climb_results");

            migrationBuilder.DropColumn(
                name: "placement",
                table: "stage_rider_standings");

            migrationBuilder.RenameTable(
                name: "mountain_climb_results",
                newName: "mountain_climb_reults");

            migrationBuilder.RenameColumn(
                name: "placement",
                table: "stage_team_standings",
                newName: "sprint_points_penalty");

            migrationBuilder.RenameIndex(
                name: "ix_mountain_climb_results_mountain_climb_id",
                table: "mountain_climb_reults",
                newName: "ix_mountain_climb_reults_mountain_climb_id");

            migrationBuilder.AddColumn<short>(
                name: "mountain_points",
                table: "stage_team_standings",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "mountain_points_penalty",
                table: "stage_team_standings",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "sprint_points",
                table: "stage_team_standings",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddUniqueConstraint(
                name: "ak_teams_team_organization_id_year",
                table: "teams",
                columns: new[] { "team_organization_id", "year" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stages_race_edition_id_stage_number",
                table: "stages",
                columns: new[] { "race_edition_id", "stage_number" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_types_name",
                table: "stage_types",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_team_standings_stage_id_race_team_participation_id",
                table: "stage_team_standings",
                columns: new[] { "stage_id", "race_team_participation_id" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_team_results_stage_id_race_team_participation_id",
                table: "stage_team_results",
                columns: new[] { "stage_id", "race_team_participation_id" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_rider_standings_stage_id_race_rider_participation_id",
                table: "stage_rider_standings",
                columns: new[] { "stage_id", "race_rider_participation_id" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_rider_results_stage_id_race_rider_participation_id",
                table: "stage_rider_results",
                columns: new[] { "stage_id", "race_rider_participation_id" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_result_status_codes_name",
                table: "stage_result_status_codes",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_result_status_codes_name_abbreviation",
                table: "stage_result_status_codes",
                column: "name_abbreviation");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_did_not_starts_stage_id_race_rider_participation_id",
                table: "stage_did_not_starts",
                columns: new[] { "stage_id", "race_rider_participation_id" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_sprint_results_sprint_id_race_rider_participation_id",
                table: "sprint_results",
                columns: new[] { "sprint_id", "race_rider_participation_id" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_races_name",
                table: "races",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_race_team_participations_race_edition_id_team_id",
                table: "race_team_participations",
                columns: new[] { "race_edition_id", "team_id" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_race_rider_participations_race_team_participation_id_rider_",
                table: "race_rider_participations",
                columns: new[] { "race_team_participation_id", "rider_id" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_race_editions_race_id_year",
                table: "race_editions",
                columns: new[] { "race_id", "year" });

            migrationBuilder.AddUniqueConstraint(
                name: "ak_nations_name",
                table: "nations",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_mountains_name",
                table: "mountains",
                column: "name");

            migrationBuilder.AddPrimaryKey(
                name: "pk_mountain_climb_reults",
                table: "mountain_climb_reults",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_combative_awards_stage_id",
                table: "stage_combative_awards",
                column: "stage_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climb_reults_mountain_climbs_mountain_climb_id",
                table: "mountain_climb_reults",
                column: "mountain_climb_id",
                principalTable: "mountain_climbs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
